using Launcher.SharedConstants;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Launcher.Cryptography
{
    public class LauncherAes
    {
        private static readonly byte[] InitVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        private readonly int _sizeOfByte = 4;

        public string Decrypt(string text, string key)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(text);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(key, null))
            {
                byte[] keyBytes = password.GetBytes(LauncherSharedConstants.AesKeySize / _sizeOfByte*2);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, InitVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        public string Encrypt(string text, string key)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(text);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(key, null))
            {
                byte[] keyBytes = password.GetBytes(LauncherSharedConstants.AesKeySize / _sizeOfByte*2);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, InitVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }
    }
}
