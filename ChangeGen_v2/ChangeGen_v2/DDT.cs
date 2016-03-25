using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

namespace ChangeGen_v2
{
    internal static class Ddt
    {
        // This method copies the folder with DDT tools to cifs on the server using PerformActionRemotely method
        private static void CopyDdTtoRemoteMachine(ServerConnectionCredentials serverCreds)
        {
            HelperMethods.PerformActionRemotely(() =>
            {
                var remotePath = "\\\\" + serverCreds.Ip + "\\C$\\DDT";
                if (Directory.Exists(remotePath)) return;
                Directory.CreateDirectory(remotePath);
                HelperMethods.DirectoryCopy("DDT", remotePath, true);
            }, serverCreds);
            Logger.Log("Successfully copied DDT to remote server", Logger.LogLevel.Info, serverCreds.Ip);
        }

        // This method runs DDT tool with specific parameters on remote server using WMI
        public static void Runddtremotely(ServerConnectionCredentials serverCreds, DdtParameters ddtParameters, CancellationToken token)
        {
            var remotePath = "\\\\" + serverCreds.Ip + "\\" + HelperMethods.SeparateVolumeAndFolder(ddtParameters.Filepath, HelperMethods.FilepathParts.Volume)
                        + "$\\" + HelperMethods.SeparateVolumeAndFolder(ddtParameters.Filepath, HelperMethods.FilepathParts.Folder);

            WmiKillDdt(serverCreds);

            CopyDdTtoRemoteMachine(serverCreds);

            Logger.Log("Data generation started on remote server " + serverCreds.Ip, Logger.LogLevel.Info, serverCreds.Ip);

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Logger.Log("DDT operation has been canceled by user", Logger.LogLevel.Info, serverCreds.Ip);
                    break;
                }

                if(!ddtParameters.FillingGeneration)
                    CleanFilepathRemotely(serverCreds, remotePath);

                WmiRunDdt(serverCreds, ddtParameters);

                Thread.Sleep(ddtParameters.Interval * 60000);
            }
        }

        // This method clean the destination folder for data generation
        private static void CleanFilepathRemotely(ServerConnectionCredentials serverCreds, string remotePath)
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
                        Logger.LogError("Remote path doesn't exist", serverCreds.Ip, e);
                        throw;
                    }
                }

                var filesTodelete = new DirectoryInfo(remotePath);
                foreach (var file in filesTodelete.GetFiles())
                {
                    file.Delete();
                }
            }, serverCreds);
        }

        // This method kills existing DDT process via WMI
        private static void WmiKillDdt(ServerConnectionCredentials serverCreds)
        {
            var options = new ConnectionOptions
            {
                Username = serverCreds.Username,
                Password = serverCreds.Password
            };


            var scope = new ManagementScope("\\\\" + serverCreds.Ip + "\\root\\cimv2", options);

            var query = new SelectQuery("select * from Win32_Process Where Name='ddt.exe'");

            var retries = 0;

            while (true)
            {
                using (var searcher = new ManagementObjectSearcher(scope, query))
                {
                    try
                    {
                        var collection = searcher.Get();
                        if (collection.Count == 0)
                        {
                            break;
                        }
                        foreach (var process in collection.Cast<ManagementObject>())
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
                            Logger.LogError("Cannot connect to remote RPC server. Retry in 30 seconds", serverCreds.Ip, e);
                            Thread.Sleep(30000);
                        }
                        else
                        {
                            Logger.LogError("Cannot connect to remote RPC server.", serverCreds.Ip, e);

                            throw;
                        }
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Logger.LogError("Access denied to remote server. Possibly incorrect credentials.", serverCreds.Ip, e);
                        throw;
                    }
                }
            }
        }

        // This methdo starts DDT on remote machine using WMI
        private static void WmiRunDdt(ServerConnectionCredentials serverCreds, DdtParameters ddtParameters)
        {
            var seed = new Random().Next();

            object[] processToTun = { @"C:\DDT\ddt.exe op=write threads=1 filename=" + ddtParameters.Filepath + seed + " filesize=" + ddtParameters.Filesize
                        + " blocksize=512 dup-percentage=" + ddtParameters.Compression + " buffering=direct io=sequential seed=" + seed + " no-ddt-hdr=yes" };
            var options = new ConnectionOptions
            {
                Username = serverCreds.Username,
                Password = serverCreds.Password
            };


            var scope = new ManagementScope("\\\\" + serverCreds.Ip + "\\root\\cimv2", options);

            var theClass = new ManagementClass(scope, new ManagementPath("Win32_Process"), new ObjectGetOptions());

            var retryCount = 0;

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
                        Logger.LogError("Starting DDT on remote machine failed with:", serverCreds.Ip, e);
                        throw;
                    }
                }
            }
        }
    }
}
