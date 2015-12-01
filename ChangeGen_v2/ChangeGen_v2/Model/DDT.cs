using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

namespace ChangeGen_v2
{
    static class DDT
    {
        // This method copies the folder with DDT tools to cifs on the server using PerformActionRemotely method
        public static void CopyDDTtoRemoteMachine(string ip, string username, string password)
        {

            HelperMethods.PerformActionRemotely(() =>
            {
                string remotePath = "\\\\" + ip + "\\C$\\DDT";
                if (!Directory.Exists(remotePath))
                {
                    Directory.CreateDirectory(remotePath);
                    HelperMethods.DirectoryCopy("DDT", remotePath, true);
                }
            }, username, password, ip);
            Logger.Log("Successfully copied DDT to server", Logger.LogLevel.Info, ip);
        }

        // This method runs DDT tool with specific parameters on remote server using WMI
        public static void Runddtremotely(string ip, string username, string password, string filepath, int filesize, int compression, int interval, CancellationToken token)
        {
            string remotePath = "\\\\" + ip + "\\" + HelperMethods.separateVolumeAndFolder(filepath, HelperMethods.FilepathParts.volume)
                        + "$\\" + HelperMethods.separateVolumeAndFolder(filepath, HelperMethods.FilepathParts.folder);

            WMIKillDDT(ip, username, password);

            CopyDDTtoRemoteMachine(ip, username, password);

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Logger.Log("DDT operation has been canceled by user", Logger.LogLevel.Info, ip);
                    break;
                }

                cleanFilepathRemotely(ip, username, password, remotePath);

                Logger.Log("Successfully deleted files in folder for data generation", Logger.LogLevel.Info, ip);

                WMIRunDDT(ip, username, password, filepath, filesize, compression);

                Logger.Log("Waiting for " + interval + " min. to create new datagen file.", Logger.LogLevel.Info, ip);
                Thread.Sleep(interval * 60000);
            }
        }

        // This method clean the destination folder for data generation
        private static void cleanFilepathRemotely(string ip, string username, string password, string remotePath)
        {
            HelperMethods.PerformActionRemotely(() =>
            {
                if (!Directory.Exists(remotePath))
                {
                    Directory.CreateDirectory(remotePath);
                }

                DirectoryInfo filesTodelete = new DirectoryInfo(remotePath);
                foreach (FileInfo file in filesTodelete.GetFiles())
                {
                    file.Delete();
                }
            }, username, password, ip);
        }

        // This method kills existing DDT process via WMI
        public static void WMIKillDDT(string ip, string username, string password)
        {
            ConnectionOptions options = new ConnectionOptions();

            options.Username = username;
            options.Password = password;

            ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);

            SelectQuery query = new SelectQuery("select * from Win32_Process Where Name='ddt.exe'");

            int retries = 0;

            while (true)
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {    
                    try
                    {
                        ManagementObjectCollection collection = searcher.Get();
                        if (collection.Count == 0)
                        {
                            break;
                        }
                        foreach (ManagementObject process in collection)
                        {
                            process.InvokeMethod("Terminate", null);
                            break;
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
        }

        // This methdo starts DDT on remote machine using WMI
        public static void WMIRunDDT(string ip, string username, string password, string filepath, int filesize, int compression)
        {
            var seed = new Random().Next();

            object[] processToTun = { @"C:\DDT\ddt.exe op=write threads=1 filename=" + filepath + seed + " filesize=" + filesize
                        + " blocksize=512 dup-percentage=" + compression + " buffering=direct io=sequential seed=" + seed + " no-ddt-hdr=yes" };
            ConnectionOptions options = new ConnectionOptions();

            options.Username = username;
            options.Password = password;

            ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);

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
        }
    }
}
