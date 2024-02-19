using PasswordManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.DAL;
using WebServerModels;

namespace PasswordManagerTest
{
    class Program
    {
        static void Main()
        {
            CheckUntilNow();
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

        static void CheckUnitOfWork()
        {
            SqliteDbContext sqliteDbContext = SqliteDbContext.GetInstance();
            UnitOfWork unitOfWork = new UnitOfWork(sqliteDbContext);
            sqliteDbContext.OpenConnection();
            foreach (User o in unitOfWork.UserRepository.ReadAll())
                Console.WriteLine($"{o.UserName}");
        }
        static void CheckUntilNow()
        {
            SecurityHelper helper = SecurityHelper.GetInstance;
            SqliteDbContext sqliteDbContext = SqliteDbContext.GetInstance();
            UnitOfWork unitOfWork = new UnitOfWork(sqliteDbContext);
            sqliteDbContext.OpenConnection();
            User user = unitOfWork.UserRepository.Read(2);
            Password password = new Password(helper, user.PasswordSalt, user.PasswordHash);
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
    }
}
