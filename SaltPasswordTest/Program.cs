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
            //sha256 returns hash of 256 bits or 64 bytes
            //256bits == 64bytes
            SecurityHelper helper = SecurityHelper.GetInstance;
            Password password = new Password("Orel6505");
            
            string TestPassword = Console.ReadLine();
            if (password.HashPassword == helper.GenerateHash(TestPassword,password.Salt))
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
