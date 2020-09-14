using System;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.Cryptography;

namespace SimplCrypto
{
    public class SimplMD5
    {
        private char[] hex_table = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        
        public SimplMD5()
        {
        }

        public string HexString(string data)
        {
            StringBuilder sb = new StringBuilder();
            byte[] bytes = Encoding.ASCII.GetBytes(data);

            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(bytes);

                foreach (var b in hash)
                {
                    sb.Append(hex_table[b >> 4]);
                    sb.Append(hex_table[b & 15]);
                }
            }

            return sb.ToString();
        }
    }
}
