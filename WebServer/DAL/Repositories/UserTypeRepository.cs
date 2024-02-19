using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebServerModels;

namespace WebServer.DAL
{
    public class UserTypeRepository : Repository, IRepository<UserType>
    {
        public UserTypeRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(object id)
        {
            string sql = $"DELETE FROM UserTypes WHERE UserTypeId=@UserTypeId";
            this.AddParam("UserTypeId", id.ToString()); //prevents SQL Injection
            return this.dbContext.Delete(sql) > 0;
        }

        public bool Delete(UserType model)
        {
            string sql = $"DELETE FROM UserTypes WHERE UserTypeId=@UserTypeId";
            this.AddParam("UserTypeId", model.UserTypeId.ToString()); //prevents SQL Injection
            return this.dbContext.Delete(sql) > 0;
        }

        public bool Insert(UserType model)
        {
            string sql = $"INSERT INTO UserTypes(UserTypeId,UserTypeName) VALUES(@UserTypeId,@UserTypeName)";
            this.AddParam("UserTypeId", model.UserTypeId.ToString()); //prevents SQL Injection
            this.AddParam("UserTypeName", model.UserTypeName); //prevents SQL Injection
            return this.dbContext.Create(sql) > 0;
        }

        public UserType Read(object id)
        {
            string sql = $"SELECT FROM UserTypes WHERE UserTypeId=@UserTypeId";
            this.AddParam("UserTypeId", id.ToString()); //prevents SQL Injection
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                dataReader.Read();
                return this.modelFactory.UserTypeModelCreator.CreateModel(dataReader);
            }
            //returns Menu
        }

        public List<UserType> ReadAll()
        {
            List<UserType> UserTypes = new List<UserType>();
            string sql = "SELECT * FROM UserTypes";
            using (IDataReader dataReader = this.dbContext.Read(sql))
                while (dataReader.Read() == true)
                    UserTypes.Add(this.modelFactory.UserTypeModelCreator.CreateModel(dataReader));
            return UserTypes;
        }

        public bool Update(UserType model)
        {
            string sql = "UPDATE UserTypes SET UserTypeName=@UserTypeName where UserTypeId=@UserTypeId";
            this.AddParam("UserTypeId", model.UserTypeId.ToString()); //prevents SQL Injection
            this.AddParam("UserTypeName", model.UserTypeName); //prevents SQL Injection
            return this.dbContext.Update(sql) > 0;
        }
    }
}