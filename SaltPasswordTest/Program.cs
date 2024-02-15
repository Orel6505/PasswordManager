using SaltPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltPasswordTest
{
    class Program
    {
        static void Main()
        {
            Salt salt = new Salt();
            string stl = salt.GenerateSalt(128);
            string Password = "12345678";
            string hashed = salt.GenerateHash(Password, stl);
            Console.WriteLine(hashed);

            //sha256 returns hash of 256 bits or 64 bytes
            //256bits == 64bytes
            Console.WriteLine(hashed.Length);
            if (hashed == salt.GenerateHash(Password, stl))
            {
                Console.WriteLine("It worked");
            }
            else
            {
                Console.WriteLine("Wrong Password");
            }
        }
    }
}
