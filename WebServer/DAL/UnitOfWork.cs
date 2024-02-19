using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.DAL;

namespace WebServer.DAL
{
    public class UnitOfWork
    {
        UserRepository userRepository;
        UserTypeRepository userTypeRepository;

        DbContext dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    this.userRepository = new UserRepository(dbContext);
                }
                return userRepository;
            }
        }

        public UserTypeRepository UserTypeRepository
        {
            get
            {
                if (userTypeRepository == null)
                {
                    this.userTypeRepository = new UserTypeRepository(dbContext);
                }
                return userTypeRepository;
            }
        }
    }
}