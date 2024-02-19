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
                UserName = Convert.ToString(source["UserId"]),
                PasswordSalt = Convert.ToString(source["UserId"]),
                PasswordHash = Convert.ToString(source["UserId"]),
                FirstName = Convert.ToString(source["UserId"]),
                LastName = Convert.ToString(source["UserId"]),
                UserTypeId = Convert.ToInt16(source["UserId"]),
                CreationDate = Convert.ToString(source["UserId"])
            };
            return user;
        }
    }
}