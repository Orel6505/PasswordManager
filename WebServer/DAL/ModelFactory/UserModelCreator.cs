using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebServerModels;

namespace WebServer.DAL.ModelFactory
{
    public class UserModelCreator : IModelCreator<User>
    {
        public User CreateModel(IDataReader source)
        {
            User user = new User()
            {
                UserId = Convert.ToInt16(source["UserId"]),
                UserName = Convert.ToString(source["UserName"]),
                PasswordSalt = Convert.ToString(source["PasswordSalt"]),
                PasswordHash = Convert.ToString(source["PasswordHash"]),
                FirstName = Convert.ToString(source["FirstName"]),
                LastName = Convert.ToString(source["LastName"]),
                UserTypeId = Convert.ToInt16(source["UserTypeId"]),
                CreationDate = Convert.ToString(source["CreationDate"])
            };
            return user;
        }
    }
}