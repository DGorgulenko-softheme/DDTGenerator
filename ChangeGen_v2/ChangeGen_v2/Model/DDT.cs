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
        public static void CopyDDTtoRemoteMachine(ServerConnectionCredentials serverCreds)
        {

            HelperMethods.PerformActionRemotely(() =>
            {
                string remotePath = "\\\\" + serverCreds.IP + "\\C$\\DDT";
                if (!Directory.Exists(remotePath))
                {
                    Directory.CreateDirectory(remotePath);
                    HelperMethods.DirectoryCopy("DDT", remotePath, true);
                }
            }, serverCreds);
            Logger.Log("Successfully copied DDT to remote server", Logger.LogLevel.Info, serverCreds.IP);
        }

        // This method runs DDT tool with specific parameters on remote server using WMI
        public static void Runddtremotely(ServerConnectionCredentials serverCreds, DDTParameters ddtParameters, CancellationToken token)
        {
            string remotePath = "\\\\" + serverCreds.IP + "\\" + HelperMethods.separateVolumeAndFolder(ddtParameters.Filepath, HelperMethods.FilepathParts.volume)
                        + "$\\" + HelperMethods.separateVolumeAndFolder(ddtParameters.Filepath, HelperMethods.FilepathParts.folder);

            WMIKillDDT(serverCreds);

            CopyDDTtoRemoteMachine(serverCreds);

            Logger.Log("Data generation started on remote server " + serverCreds.IP, Logger.LogLevel.Info, serverCreds.IP);

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Logger.Log("DDT operation has been canceled by user", Logger.LogLevel.Info, serverCreds.IP);
                    break;
                }

                cleanFilepathRemotely(serverCreds, remotePath);

                WMIRunDDT(serverCreds, ddtParameters);

                Thread.Sleep(ddtParameters.Interval * 60000);
            }
        }

        // This method clean the destination folder for data generation
        private static void cleanFilepathRemotely(ServerConnectionCredentials serverCreds, string remotePath)
        {
            HelperMethods.PerformActionRemotely(() =>
            {
                if (!Directory.Exists(remotePath))
                {
                    try
                    {
                        Directory.CreateDirectory(remotePath);
                    }
                    catch (IOException e)
                    {
                        Logger.LogError("Remote path doesn't exist", serverCreds.IP, e);
                        throw;
                    }
                }

                DirectoryInfo filesTodelete = new DirectoryInfo(remotePath);
                foreach (FileInfo file in filesTodelete.GetFiles())
                {
                    file.Delete();
                }
            }, serverCreds);
        }

        // This method kills existing DDT process via WMI
        public static void WMIKillDDT(ServerConnectionCredentials serverCreds)
        {
            ConnectionOptions options = new ConnectionOptions();

            options.Username = serverCreds.Username;
            options.Password = serverCreds.Password;

            ManagementScope scope = new ManagementScope("\\\\" + serverCreds.IP + "\\root\\cimv2", options);

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
                            Logger.LogError("Cannot connect to remote RPC server. Retry in 30 seconds", serverCreds.IP, e);
                            Thread.Sleep(30000);
                        }
                        else
                        {
                            Logger.LogError("Cannot connect to remote RPC server.", serverCreds.IP, e);

                            throw;
                        }
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Logger.LogError("Access denied to remote server. Possibly incorrect credentials.", serverCreds.IP, e);
                        throw;
                    }
                }
            }
        }

        // This methdo starts DDT on remote machine using WMI
        public static void WMIRunDDT(ServerConnectionCredentials serverCreds, DDTParameters ddtParameters)
        {
            var seed = new Random().Next();

            object[] processToTun = { @"C:\DDT\ddt.exe op=write threads=1 filename=" + ddtParameters.Filepath + seed + " filesize=" + ddtParameters.Filesize
                        + " blocksize=512 dup-percentage=" + ddtParameters.Compression + " buffering=direct io=sequential seed=" + seed + " no-ddt-hdr=yes" };
            ConnectionOptions options = new ConnectionOptions();

            options.Username = serverCreds.Username;
            options.Password = serverCreds.Password;

            ManagementScope scope = new ManagementScope("\\\\" + serverCreds.IP + "\\root\\cimv2", options);

            ManagementClass theClass = new ManagementClass(scope, new ManagementPath("Win32_Process"), new ObjectGetOptions());

            int retryCount = 0;

            while (true)
            {
                try
                {
                    theClass.InvokeMethod("Create", processToTun);
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
                        Logger.LogError("Starting DDT on remote machine failed with:", serverCreds.IP, e);
                        throw;
                    }
                }
            }
        }
    }
}
