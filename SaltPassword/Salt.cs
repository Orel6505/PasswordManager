using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }
    }
}
