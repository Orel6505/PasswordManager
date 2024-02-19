using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebServerModels;

namespace WebServer.DAL.ModelFactory
{
    public class UserTypeModelCreator : IModelCreator<UserType>
    {
        public UserType CreateModel(IDataReader source)
        {
            UserType userType = new UserType()
            {
                UserTypeId = Convert.ToInt16(source["UserTypeId"]),
                UserTypeName = Convert.ToString(source["UserTypeName"]),
            };
            return userType;
        }
    }
}