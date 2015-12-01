using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;

namespace ChangeGen_v2
{
    static class HelperMethods
    {

        // This method is using for connection to the remote CIFS share with specific credentials
        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        // This method is used to perform action delegate remotely on CIFS Share
        private static void PerformActionRemotely(Action action, string username, string password, string ip)
        {
            WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
            WindowsImpersonationContext wic = null;
            try
            {
                IntPtr admin_token = new IntPtr();
                if (LogonUser(username, ".", password, 9, 0, ref admin_token) != 0)
                {
                    wic = new WindowsIdentity(admin_token).Impersonate();

                    action();
                }
                else
                {

                }
            }
            catch (Exception se)
            {
                int ret = Marshal.GetLastWin32Error();
                Logger.Log("Invoking action on remote machine failed with: " + Environment.NewLine
                    + "Error code: " + ret.ToString() + Environment.NewLine + se.Message + Environment.NewLine + se.StackTrace, Logger.LogLevel.Error, ip);
                return;
            }
            finally
            {
                if (wic != null)
                {
                    wic.Undo();
                }
            }
        }

        // This method copies the folder with DDT tools to cifs on the server using PerformActionRemotely method
        public static void CopyDDTtoRemoteMachine(string ip, string username, string password)
        {
            
                PerformActionRemotely(() =>
                {
                    string remotePath = "\\\\" + ip + "\\C$\\DDT";
                    if (!Directory.Exists(remotePath))
                    {
                        Directory.CreateDirectory(remotePath);
                        DirectoryCopy("DDT", remotePath, true);
                    }
                }, username, password, ip);
                Logger.Log("Successfully copied DDT to server", Logger.LogLevel.Info, ip);

            

        }

        // This method implements copying of folders
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            DirectoryInfo[] dirs = dir.GetDirectories();

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);


                file.CopyTo(temppath, true);
                
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        // This method runs DDT tool with specific parameters on remote server using WMI
        public static void Runddtremotely(string ip, string username, string password, string filepath, int filesize, int compression, int interval, CancellationToken token)
        {
            ConnectionOptions options = new ConnectionOptions();

            options.Username = username;
            options.Password = password;

            ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);


            SelectQuery query = new SelectQuery("select * from Win32_Process Where Name='ddt.exe'");

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                int retries = 0;
                {
                    try
                    {
                        ManagementObjectCollection collection = searcher.Get();
                        foreach (ManagementObject process in collection)
                        {
                            process.InvokeMethod("Terminate", null);
                        }
                    }
                    catch (COMException e)
                    {
                        if (retries < 3)
                        {
                            retries++;
                        }
                        else
                        {
                            Logger.Log("Killing DDT on remote machine failed with: " + Environment.NewLine + e.Message
                            + Environment.NewLine + e.StackTrace, Logger.LogLevel.Error, ip);
                            throw e;
                        }
                    }
                }
                
            }


            
            CopyDDTtoRemoteMachine(ip, username, password);

            

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Logger.Log("DDT operation has been canceled by user", Logger.LogLevel.Info, ip);
                    break;
                }

                PerformActionRemotely(() =>
                {
                    string remotePath = "\\\\" + ip + "\\" + separateVolumeAndFolder(filepath, NameParts.volume)
                        + "$\\" + separateVolumeAndFolder(filepath, NameParts.folder);
                    if (!Directory.Exists(remotePath))
                    {
                        Directory.CreateDirectory(remotePath);
                    }
                        
                    DirectoryInfo filesTodelete = new DirectoryInfo("\\\\" + ip + "\\" + separateVolumeAndFolder(filepath, NameParts.volume)
                        + "$\\" + separateVolumeAndFolder(filepath, NameParts.folder));
                    foreach (FileInfo file in filesTodelete.GetFiles())
                    {
                        file.Delete();
                    }
                }, username, password, ip);

                Logger.Log("Successfully deleted files in folder for data generation", Logger.LogLevel.Info, ip);

                var seed = new Random().Next();

                object[] processToTun = { @"C:\DDT\ddt.exe op=write threads=1 filename=" + filepath + seed + " filesize=" + filesize
                        + " blocksize=512 dup-percentage=" + compression + " buffering=direct io=sequential seed=" + seed + " no-ddt-hdr=yes" };
                //ConnectionOptions options = new ConnectionOptions();

                options.Username = username;
                options.Password = password;

                //ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);

                ManagementClass theClass = new ManagementClass(scope, new ManagementPath("Win32_Process"), new ObjectGetOptions());


                int retryCount = 0;

                while (true)
                {
                    try
                    {
                        theClass.InvokeMethod("Create", processToTun);
                        Logger.Log("DDT succesfully performed data generation.", Logger.LogLevel.Info, ip);
                        break;
                    }
                    catch (COMException e)
                    {
                        if (retryCount < 3)
                        {
                            retryCount++;
                        }
                        else
                        {
                            Logger.Log("Starting DDT on remote machine failed with: " + Environment.NewLine + e.Message
                            + Environment.NewLine + e.StackTrace, Logger.LogLevel.Error, ip);
                            throw e;
                        }

                    }
                }



                Logger.Log("Waiting for " + interval + " min. to create new datagen file.", Logger.LogLevel.Info, ip);
                Thread.Sleep(interval * 60000);

            }
        }

        public static String separateVolumeAndFolder(string stringToSeparate, NameParts partToSeparate)
        {
            var separatorIndex = stringToSeparate.IndexOf(':');
            switch (partToSeparate)
            {
                case NameParts.volume:
                    return stringToSeparate.Remove(separatorIndex);
                case NameParts.folder:
                    return stringToSeparate.Remove(0, separatorIndex + 1);
                default:
                    return null;
            }
        }

        public enum NameParts
        {
            volume,
            folder
        }
    }
}
