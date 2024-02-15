using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltPassword
{
    public class Salt : ISalt
    {
        public string GenerateHash(string Password, string Salt)
        {
            throw new NotImplementedException();
        }

        public string GenerateSalt(int Length)
        {
            throw new NotImplementedException();
        }
    }
}
