using System;
using System.IO;
using System.Security.Cryptography;

namespace Launcher.Helpers
{
    public static class MD5Helper
    {
        public static string GetChecksum(string file)
        {
            if (!File.Exists(file))
                return null;
            FileStream stream = File.OpenRead(file);
            var sha = new MD5CryptoServiceProvider();
            byte[] checksum = sha.ComputeHash(stream);
            return BitConverter.ToString(checksum).Replace("-", string.Empty);
        }

        public static string GetChecksumBuffered(string file, bool dispose = true)
        {
            if (!File.Exists(file))
                return null;
            FileStream stream = File.OpenRead(file);
            return GetChecksumBuffered(stream, dispose);
        }

        static BufferedStream tmpStream;
        public static string GetChecksumBuffered(Stream stream, bool dispose = true)
        {
            tmpStream = new BufferedStream(stream, 1024 * 32);
            var sha = new MD5CryptoServiceProvider();
            byte[] checksum = sha.ComputeHash(tmpStream);
            sha.Dispose();
            if (dispose)
            {
                tmpStream.Dispose();
                tmpStream.Close();
            }
            return BitConverter.ToString(checksum).Replace("-", string.Empty);
        }

        public static void ReleaseStream()
        {
            tmpStream.Dispose();
            tmpStream.Close();
        }
    }
}
