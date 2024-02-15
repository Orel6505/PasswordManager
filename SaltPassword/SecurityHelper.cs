using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SaltPassword
{
    public class SecurityHelper : ISecurityHelper
    {
        static SecurityHelper instance;
        private SecurityHelper() {}
        public static SecurityHelper GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SecurityHelper();
                }
                return instance;
            }
        }
        /// <summary>Creates Random Salt for hashing password</summary>
        /// <returns>Returns random array of letters with length of the value given</returns>
        public string GenerateSalt(int Length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            string salt = "";
            for (int i = 0; i < Length; i++)
                salt += chars[rnd.Next(0, chars.Length)];
            return salt;
        }

        /// <summary>Takes <paramref name="Password"/> and <paramref name="Salt"/> and Hashes it with SHA256 Hash Alghoritm</summary>
        /// <returns>Returns a hashed string</returns>
        public string GenerateHash(string Password, string Salt)
        {
            using (HashAlgorithm sha256 = SHA256.Create())
            {
                // ComputeHash - Generate hash from the provided Text and returns it as list of bytes
                byte[] bhash = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password + Salt));
                // Convert byte[] to a string
                string hash = "";
                foreach(byte pbhash in bhash)
                {
                    hash+=pbhash.ToString("x2");
                }
                return hash.ToString();
            }
        }
    }
}
