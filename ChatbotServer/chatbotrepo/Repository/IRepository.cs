using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbotrepo.Repository
{
    interface IRepository<T> where T : class
    {
        DbSet<T> GetAll();
        void AddOne(T record);
    }
}
