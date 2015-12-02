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
        public static void CopyDDTtoRemoteMachine(string ip, ServerConnectionCredentials serverCreds)
        {

            HelperMethods.PerformActionRemotely(() =>
            {
                string remotePath = "\\\\" + ip + "\\C$\\DDT";
                if (!Directory.Exists(remotePath))
                {
                    Directory.CreateDirectory(remotePath);
                    HelperMethods.DirectoryCopy("DDT", remotePath, true);
                }
            }, serverCreds, ip);
            Logger.Log("Successfully copied DDT to server", Logger.LogLevel.Info, ip);
        }

        // This method runs DDT tool with specific parameters on remote server using WMI
        public static void Runddtremotely(string ip, ServerConnectionCredentials serverCreds, DDTParameters ddtParameters, CancellationToken token)
        {
            string remotePath = "\\\\" + ip + "\\" + HelperMethods.separateVolumeAndFolder(ddtParameters.Filepath, HelperMethods.FilepathParts.volume)
                        + "$\\" + HelperMethods.separateVolumeAndFolder(ddtParameters.Filepath, HelperMethods.FilepathParts.folder);

            WMIKillDDT(ip, serverCreds.Username, serverCreds.Password);

            CopyDDTtoRemoteMachine(ip, serverCreds);

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Logger.Log("DDT operation has been canceled by user", Logger.LogLevel.Info, ip);
                    break;
                }

                cleanFilepathRemotely(ip, serverCreds, remotePath);

                Logger.Log("Successfully deleted files in folder for data generation", Logger.LogLevel.Info, ip);

                WMIRunDDT(ip, serverCreds.Username, serverCreds.Password, ddtParameters);

                Logger.Log("Waiting for " + ddtParameters.Interval + " min. to create new datagen file.", Logger.LogLevel.Info, ip);

                Thread.Sleep(ddtParameters.Interval * 60000);
            }
        }

        // This method clean the destination folder for data generation
        private static void cleanFilepathRemotely(string ip, ServerConnectionCredentials serverCreds, string remotePath)
        {
            HelperMethods.PerformActionRemotely(() =>
            {
                if (!Directory.Exists(remotePath))
                {
                    try
                    {
                        Directory.CreateDirectory(remotePath);
                    }
                    catch(IOException e)
                    {
                        Logger.LogError("Remote path doesn't exist", ip, e);
                        throw;
                    }
                }

                DirectoryInfo filesTodelete = new DirectoryInfo(remotePath);
                foreach (FileInfo file in filesTodelete.GetFiles())
                {
                    file.Delete();
                }
            }, serverCreds, ip);
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
                            Logger.LogError("Cannot connect to remote RPC server. Retry in 30 seconds", ip, e);
                            Thread.Sleep(30000);
                        }
                        else
                        {
                            Logger.LogError("Cannot connect to remote RPC server.", ip, e);

                            throw;
                        }
                    }
                    catch(UnauthorizedAccessException e)
                    {
                        Logger.LogError("Access denied to remote server. Possibly incorrect credentials.", ip, e);
                        throw;
                    }
                }       
            }
        }

        // This methdo starts DDT on remote machine using WMI
        public static void WMIRunDDT(string ip, string username, string password, DDTParameters ddtParameters)
        {
            var seed = new Random().Next();

            object[] processToTun = { @"C:\DDT\ddt.exe op=write threads=1 filename=" + ddtParameters.Filepath + seed + " filesize=" + ddtParameters.Filesize
                        + " blocksize=512 dup-percentage=" + ddtParameters.Compression + " buffering=direct io=sequential seed=" + seed + " no-ddt-hdr=yes" };
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
                        Logger.LogError("Starting DDT on remote machine failed with:", ip, e);
                        throw;
                    }
                }
            }
        }
    }
}
