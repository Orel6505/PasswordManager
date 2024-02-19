using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.DAL
{
    public class ModelFactory
    {
        UserModelCreator userModelCreator;
        UserTypeModelCreator userTypeModelCreator;
        PasswordModelCreator passwordModelCreator;

        public UserModelCreator UserModelCreator
        {
            get
            {
                if (userModelCreator == null)
                {
                    this.userModelCreator = new UserModelCreator();
                }
                return userModelCreator;
            }
        }

        public UserTypeModelCreator UserTypeModelCreator
        {
            get
            {
                if (userTypeModelCreator == null)
                {
                    this.userTypeModelCreator = new UserTypeModelCreator();
                }
                return userTypeModelCreator;
            }
        }
        public PasswordModelCreator PasswordModelCreator
        {
            get
            {
                if (passwordModelCreator == null)
                {
                    this.passwordModelCreator = new PasswordModelCreator();
                }
                return passwordModelCreator;
            }
        }
    }
}