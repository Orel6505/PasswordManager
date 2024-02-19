using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebServerModels;

namespace WebServer.DAL
{
    public class UserRepository : Repository, IRepository<User>
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(object id)
        {
            string sql = $"DELETE FROM Users WHERE UserId=@UserId";
            this.AddParam("UserId", id.ToString()); //prevents SQL Injection
            return this.dbContext.Delete(sql) > 0;
        }

        public bool Delete(User model)
        {
            string sql = $"DELETE FROM Users WHERE UserId=@UserId";
            this.AddParam("UserId", model.UserId.ToString()); //prevents SQL Injection
            return this.dbContext.Delete(sql) > 0;
        }

        public bool Insert(User model)
        {
            string sql = $"INSERT INTO Users(UserName,FirstName,LastName,PassWordHash,PasswordSalt,UserTypeld,CreationDate) VALUES(@UserName,@FirstName,@LastName,@PasswordHash,@PasswordSalt,@UserTypeld,@CreationDate)";
            this.AddParam("UserName", model.UserName); //prevents SQL Injection
            this.AddParam("FirstName", model.FirstName); //prevents SQL Injection
            this.AddParam("LastName", model.LastName); //prevents SQL Injection
            this.AddParam("PassWordHash", model.PasswordHash); //prevents SQL Injection
            this.AddParam("PasswordSalt", model.PasswordSalt); //prevents SQL Injection
            this.AddParam("UserTypeId", model.UserTypeId.ToString()); //prevents SQL Injection
            this.AddParam("CreationDate", model.CreationDate); //prevents SQL Injection
            return this.dbContext.Create(sql) > 0;
        }

        public User Read(object id)
        {
            string sql = $"SELECT * FROM Users WHERE UserId=@UserId";
            this.AddParam("UserId", id.ToString()); //prevents SQL Injection
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                dataReader.Read();
                return this.modelFactory.UserModelCreator.CreateModel(dataReader);
            }
            //returns User
        }

        public List<User> ReadAll()
        {
            List<User> Users = new List<User>();
            string sql = "SELECT * FROM Users";
            using (IDataReader dataReader = this.dbContext.Read(sql))
                while (dataReader.Read() == true)
                    Users.Add(this.modelFactory.UserModelCreator.CreateModel(dataReader));
            return Users;
        }

        public bool Update(User model)
        {
            string sql = "UPDATE Users SET UserName=@UserName, FirstName=@FirstName, LastName=@LastName, PassWordHash=@PassWordHash, PasswordSalt=@PasswordSalt, UserTypeId=@UserTypeId, CreationDate=@CreationDate where UserId=@UserId";
            this.AddParam("UserId", model.UserId.ToString()); //prevents SQL Injection
            this.AddParam("UserName", model.UserName); //prevents SQL Injection
            this.AddParam("FirstName", model.FirstName); //prevents SQL Injection
            this.AddParam("LastName", model.LastName); //prevents SQL Injection
            this.AddParam("PassWordHash", model.PasswordHash); //prevents SQL Injection
            this.AddParam("PasswordSalt", model.PasswordSalt); //prevents SQL Injection
            this.AddParam("UserTypeId", model.UserTypeId.ToString()); //prevents SQL Injection
            this.AddParam("CreationDate", model.CreationDate); //prevents SQL Injection
            return this.dbContext.Update(sql) > 0;
        }
    }
}