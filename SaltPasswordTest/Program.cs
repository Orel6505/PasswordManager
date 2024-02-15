using SaltPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltPasswordTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Salt salt = new Salt();
            Console.WriteLine(salt.GenerateSalt(128));
        }
    }
}
