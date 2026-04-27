using System;
using System.IO;
using System.Security.Cryptography;
using WiFiSwapper.Code.Extensions;

namespace WiFiSwapper.Core
{
    public class Password
    {
        public static string GenerateSeed(int length)
        {
            byte[] randomBytes = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes).Substring(0, length);
        }

        public static byte[] Encrypt(string plainText, string seed)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set key and IV from seed
                aesAlg.Key = GetKeyFromSeed(seed);
                aesAlg.IV = new byte[16]; // Initialization vector (initialized with zeros in this case)

                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // We encrypt the text
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        public static string Decrypt(byte[] cipherText, string seed)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set key and IV from seed
                aesAlg.Key = GetKeyFromSeed(seed);
                aesAlg.IV = new byte[16]; // Initialization vector (initialized with zeros in this case)

                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    // We decrypt the text
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        private static byte[] GetKeyFromSeed(string seed)
        {
            // Convert the seed to a byte array and set the key length to 16 bytes
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] keyBytes = sha256Hash.ComputeHash(seed.ToByteArray());
                byte[] key = new byte[16]; // AES key is 128 bits long (16 bytes)
                Array.Copy(keyBytes, key, 16);
                return key;
            }
        }
    }
}
