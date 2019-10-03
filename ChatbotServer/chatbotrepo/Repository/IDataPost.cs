using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chatbotrepo.DAL;

namespace chatbotrepo
{
    public interface IDataPost
    {
        int SaveCustomer(CustomersTbl customer);
        DbSet<CustomersTbl> GetCustomers();
    }
}
