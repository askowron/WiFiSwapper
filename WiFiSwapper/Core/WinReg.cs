using Microsoft.Win32;
using System;

namespace WiFiSwapper.Core
{
    public class WinReg
    {
        /// <summary>
        /// Read binary date from registry
        /// </summary>
        /// <param name="path">Key path</param>
        /// <param name="keyName">Key name</param>
        /// <returns>Key value</returns>
        public static byte[] ReadByteArray(string path, string keyName)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
            if (key != null)
            {
                object data = key.GetValue(keyName);
                key.Close();
                if (data != null)
                    return (byte[])data;
            }

            return new byte[0];
        }

        /// <summary>
        /// Write binary data to registry
        /// </summary>
        /// <param name="path">Key path</param>
        /// <param name="keyName">Key name</param>
        /// <param name="data">Key value</param>
        /// <param name="createPathIfNotExists">Auto create Path if not exists</param>
        public static void WriteByteArray(string path, string keyName, byte[] data, bool createPathIfNotExists = true)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
                if (key == null && createPathIfNotExists)
                    key = Registry.CurrentUser.CreateSubKey(path, true);

                if (key == null)
                    throw new Exception("Couldn't create Registry Key!");

                key.SetValue(keyName, data, RegistryValueKind.Binary);
                key.Close();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void RemovePath(string path)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
                key.DeleteSubKeyTree(Constants.LOCK);
                key.Close();
            }
            catch (Exception exc) 
            {
                throw exc;
            }
        }

        public static bool KeyExists(string keyName)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName);
            if (key != null)
            {
                key.Close();
                return true;
            }

            return false;
        }
    }
}
