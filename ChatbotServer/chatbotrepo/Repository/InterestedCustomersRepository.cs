using chatbotrepo.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace chatbotrepo.Repository
{
    public class InterestedCustomersRepository : IRepository<InterestsTbl>
    {
        private ChatbotEntities _dbContext;

        public InterestedCustomersRepository()
        {
            _dbContext = new ChatbotEntities();
        }

        public void AddOne(InterestsTbl record)
        {
            _dbContext.InterestsTbls.Add(record);
            _dbContext.SaveChanges();
        }

        public DbSet<InterestsTbl> GetAll()
        {
            return _dbContext.InterestsTbls;
        }

        public InterestsTbl GetById(int parameter)
        {
            return (from i in _dbContext.InterestsTbls
                    where i.customer_id == parameter
                    select i).SingleOrDefault();
        }

        public int? GetMonitorById(int parameter)
        {
            return ( from i in _dbContext.InterestsTbls where i.customer_id == parameter select i.monitor_id).FirstOrDefault();
        }
         
    }
}