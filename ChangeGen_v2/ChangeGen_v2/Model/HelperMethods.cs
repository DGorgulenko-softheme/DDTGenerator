using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ChangeGen_v2
{
    static class HelperMethods
    {

        // This method is using for connection to the remote CIFS share with specific credentials
        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        // This method is used to perform action delegate remotely on CIFS Share
        public static void PerformActionRemotely(Action action, ServerConnectionCredentials serverCreds, string ip)
        {
            WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
            WindowsImpersonationContext wic = null;
            try
            {
                IntPtr admin_token = new IntPtr();
                if (LogonUser(serverCreds.Username, ".", serverCreds.Password, 9, 0, ref admin_token) != 0)
                {
                    wic = new WindowsIdentity(admin_token).Impersonate();

                    action();
                }
            }
            catch (Exception se)
            {
                int ret = Marshal.GetLastWin32Error();
                Logger.LogError("Invoking action on remote machine failed with Error code " + ret.ToString(), ip, se);
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

        // This method implements copying of folders
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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

        public static String separateVolumeAndFolder(string stringToSeparate, FilepathParts partToSeparate)
        {
            var separatorIndex = stringToSeparate.IndexOf(':');
            switch (partToSeparate)
            {
                case FilepathParts.volume:
                    return stringToSeparate.Remove(separatorIndex);
                case FilepathParts.folder:
                    return stringToSeparate.Remove(0, separatorIndex + 1);
                default:
                    return null;
            }
        }

        public enum FilepathParts
        {
            volume,
            folder
        }


    }


}
