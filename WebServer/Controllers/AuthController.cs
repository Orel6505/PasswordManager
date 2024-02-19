using PasswordManager;
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
    public class AuthController : ApiController
    {
        [HttpGet]
        public bool CheckLogin(string Username, string password)
        {
            SqliteDbContext sqliteDbContext = SqliteDbContext.GetInstance();
            UnitOfWork unitOfWork = new UnitOfWork(sqliteDbContext);
            SecurityHelper helper = SecurityHelper.GetInstance;
            Password existpassword;
            try
            {
                sqliteDbContext.OpenConnection();
                existpassword = unitOfWork.UserRepository.ReadPassByUsername(helper, Username);
                return existpassword.IsSamePassword(password);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            finally
            {
                sqliteDbContext.CloseConnection();
            }
            return false;
        }
    }
}