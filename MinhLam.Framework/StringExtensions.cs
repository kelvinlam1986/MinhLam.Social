using System;

namespace MinhLam.Framework
{
    public static class StringExtensions
    {
        public static string Encrypt(this string s, string key)
        {
            return Cryptography.Encrypt(s, key);
        }
        public static string Decrypt(this string s, string key)
        {
            return Cryptography.Decrypt(s, key);
        }

        //CHAPTER 4
        public static string TimestampToString(this byte[] binary)
        {
            string result = "";
            foreach (byte b in binary)
            {
                result += b.ToString() + "|";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        //CHAPTER 4
        public static byte[] StringToTimestamp(this string s)
        {
            string[] arr = s.Split('|');
            byte[] bytes = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bytes[i] = Convert.ToByte(arr[i]);
            }
            return bytes;
        }

        //CHAPTER 4
        public static string ToMD5Hash(this string s)
        {
            return Cryptography.CreateMD5Hash(s);
        }
    }
}
