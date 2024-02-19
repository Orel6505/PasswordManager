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
    public class UserController : ApiController
    {
        [HttpGet]
        public User GetUserByName(int id)
        {
            SqliteDbContext sqliteDbContext = SqliteDbContext.GetInstance();
            UnitOfWork unitOfWork = new UnitOfWork(sqliteDbContext);
            User user;
            try
            {
                sqliteDbContext.OpenConnection();
                user = unitOfWork.UserRepository.Read(id);
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
            return user;
        }
    }
}