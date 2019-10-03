using chatbotrepo.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace chatbotrepo.Repository
{
    public class CustomerOrdersRepository : IRepository<OrdersTbl>
    {
        private ChatbotEntities _dbContext;

        public CustomerOrdersRepository()
        {
            _dbContext = new ChatbotEntities();
        }

      

        public void AddOne(OrdersTbl record)
        {
            _dbContext.OrdersTbls.Add(record);
            _dbContext.SaveChanges();
        }

        public DbSet<OrdersTbl> GetAll()
        {
            return _dbContext.OrdersTbls;
        }

        public OrdersTbl GetById(int parameter)
        {
            return (from i in _dbContext.OrdersTbls
                    where i.customer_id == parameter
                    select i).SingleOrDefault();
        }
        public string GetMonitorById(int parameter)
        {
           return (from i in _dbContext.OrdersTbls
               join m in _dbContext.MonitorsTbls on i.monitor_id equals m.monitor_id
               where i.customer_id == parameter
               select m.monitor_name).FirstOrDefault();

        }
    }
}