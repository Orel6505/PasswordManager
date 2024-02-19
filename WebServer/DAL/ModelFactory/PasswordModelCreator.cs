using PasswordManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebServer.DAL
{
    public class PasswordModelCreator
    {
        public Password CreateModel(IDataReader source, SecurityHelper helper)
        {
            return new Password(helper, Convert.ToString(source["PasswordSalt"]), Convert.ToString(source["PasswordHash"]));
        }
    }
}