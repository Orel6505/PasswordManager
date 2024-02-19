using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace WebServer.DAL
{
    public class Repository
    {
        protected DbContext dbContext;
        protected ModelFactory modelFactory;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext; //Dependency Injection
            this.modelFactory = new ModelFactory();
        }

        protected void AddParam(string paramName, string paramValue)
        {
            this.dbContext.AddParam(new SQLiteParameter(paramName, paramValue));
        }
    }
}