using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebServer.DAL;
using WebServerModels;

namespace WebServer.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public List<User> GetUsers()
        {
            SqliteDbContext sqliteDbContext = SqliteDbContext.GetInstance();
            UnitOfWork unitOfWork = new UnitOfWork(sqliteDbContext);
            List<User> Users;
            try
            {
                sqliteDbContext.OpenConnection();
                Users = unitOfWork.UserRepository.ReadAll();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return null;
            }
            finally
            {
                sqliteDbContext.CloseConnection();
            }
            return Users;
        }
    }
}