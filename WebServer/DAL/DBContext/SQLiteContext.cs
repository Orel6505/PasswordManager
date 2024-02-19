using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.Sqlite;

namespace WebServer.DAL.DBContext
{
    public class SqliteDbContext : DbContext
    {
        static SqliteDbContext sqliteDbContext;
        static object blocker = new object();
        private SqliteDbContext()
        {
            this.connection = new SqliteConnection();
            this.connection.ConnectionString = CommonParam.ConnectionString; // tells which type of sql we are connecting to and tell its directory
        }

        public static SqliteDbContext GetInstance()
        {
            lock (blocker)
            {
                if (sqliteDbContext == null)
                    sqliteDbContext = new SqliteDbContext(); //implement singleton design pattern
                return sqliteDbContext;
            }
        }
    }
}