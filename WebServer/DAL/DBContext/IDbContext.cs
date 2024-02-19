using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebServer.DAL.DBContext
{
    public interface IDbContext
    {
        //Data Access Layer

        //Create
        int Create(string sql);

        //Read
        IDataReader Read(string sql);
        object ReadValue(string sql);

        //Update
        int Update(string sql);

        //Delete
        int Delete(string sql);

        //Open and Close Connection
        void OpenConnection();
        void CloseConnection();

        //Create Command
        void CreateCommand();

    }
}