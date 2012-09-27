using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FindPasswordMD5HashExem
{
    public static class CalculateMd5
    {
        public static string CalculateMd5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);


            return BitConverter.ToString(hash);
            // step 2, convert byte array to hex string
            /*StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();*/

            //return Encoding.UTF8.GetString((new MD5CryptoServiceProvider()).ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
        
    }
}
