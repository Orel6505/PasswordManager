using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltPassword
{
    public class Password
    {
        private SecurityHelper Instance;
        public string Salt { get; set; }
        public string HashPassword { get; set; }

        /// <summary> Creates object of password which contains <see cref="Salt"/> and <see cref="HashPassword"/></summary>
        public Password(string Password)
        {
            this.Instance = SecurityHelper.GetInstance;
            this.Salt = Instance.GenerateSalt(64);
            this.HashPassword = Instance.GenerateHash(Password,this.Salt);
        }

        /// <summary> Creates object of password which contains <see cref="Salt"/> and <see cref="HashPassword"/></summary>
        public Password(string Salt, string Password)
        {
            this.Instance = SecurityHelper.GetInstance;
            this.Salt = Salt;
            this.HashPassword = Instance.GenerateHash(Password, this.Salt);
        }
    }
}
