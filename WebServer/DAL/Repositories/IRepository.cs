using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.DAL
{
    public interface IRepository<T>
    {
        //this part is responsible for the logic part in Data access layer
        //CRUD - Create Read Update Delete

        //Create 
        bool Insert(T model);

        //Read
        List<T> ReadAll(); //all sets that contains a specific value
        T Read(object id); //only a specific set

        //Update
        bool Update(T model);

        //Delete
        bool Delete(object id);
        bool Delete(T model);
    }
}
