using PasswordManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.DAL.DBContext;
using WebServer.DAL.ModelFactory;
using WebServerModels;

namespace PasswordManagerTest
{
    class Program
    {
        static void Main()
        {
            CheckModelFactory();
        }
        static void CheckPasswordManager()
        {
            //sha256 returns hash of 256 bits or 64 bytes
            //256bits == 64bytes
            SecurityHelper helper = SecurityHelper.GetInstance;
            Password password = new Password(helper, "Orel6505", 64);

            string EnteredPassword = Console.ReadLine();
            if (password.IsSamePassword(EnteredPassword))
            {
                Console.WriteLine("It worked");
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }
        }

        static void CheckModelFactory()
        {
            SqliteDbContext sqliteDbContext = SqliteDbContext.GetInstance();
            ModelFactory modelFactory = new ModelFactory();
            string sql = "Select * from Users";
            sqliteDbContext.OpenConnection();
            IDataReader dataReader = sqliteDbContext.Read(sql);
            List<User> users = new List<User>();
            while (dataReader.Read() == true)
            {
                User user = modelFactory.UserModelCreator.CreateModel(dataReader);
                users.Add(user);
            }
            sqliteDbContext.CloseConnection();
            foreach (User o in users)
                Console.WriteLine($"{o.PasswordHash}");
        }
    }
}
