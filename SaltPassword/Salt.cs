using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SaltPassword
{
    public class Salt : ISalt
    {
        public string GenerateSalt(int Length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            string salt = "";
            for (int i = 0; i < Length; i++)
                salt += chars[rnd.Next(0, chars.Length)];
            return salt;
        }

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
