using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ChangeGen_v2
{
    internal static class HelperMethods
    {
        // This method is using for connection to the remote CIFS share with specific credentials
        [DllImport("advapi32.DLL", SetLastError = true)]
        private static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        // This method is used to perform action delegate remotely on CIFS Share
        public static void PerformActionRemotely(Action action, ServerConnectionCredentials serverCreds)
        {
            WindowsIdentity.GetCurrent();
            WindowsImpersonationContext wic = null;
            try
            {
                var adminToken = new IntPtr();
                if (LogonUser(serverCreds.Username, ".", serverCreds.Password, 9, 0, ref adminToken) == 0) return;
                wic = new WindowsIdentity(adminToken).Impersonate();

                action();
            }
            catch (Exception se)
            {
                var ret = Marshal.GetLastWin32Error();
                Logger.LogError("Invoking action on remote machine failed with Error code " + ret.ToString(), serverCreds.Ip, se);
                return;
            }
            finally
            {
                wic?.Undo();
            }
        }

        // This method implements copying of folders
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);

            var dirs = dir.GetDirectories();

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var temppath = Path.Combine(destDirName, file.Name);


                file.CopyTo(temppath, true);
                
            }

            if (!copySubDirs) return;
            {
                foreach (var subdir in dirs)
                {
                    var temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, true);
                }
            }
        }

        public static string SeparateVolumeAndFolder(string stringToSeparate, FilepathParts partToSeparate)
        {
            var separatorIndex = stringToSeparate.IndexOf(':');
            switch (partToSeparate)
            {
                case FilepathParts.Volume:
                    return stringToSeparate.Remove(separatorIndex);
                case FilepathParts.Folder:
                    return stringToSeparate.Remove(0, separatorIndex + 1);
                default:
                    return null;
            }
        }

        public enum FilepathParts
        {
            Volume,
            Folder
        }
    }
}
