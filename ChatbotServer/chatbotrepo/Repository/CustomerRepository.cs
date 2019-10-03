using chatbotrepo.DAL;
using CustomerDetailsDataModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace chatbotrepo
{
    public class CustomerRepository:IDataPost
    {
        #region Private Fields
        private readonly ChatbotEntities _context;
        #endregion

        #region Constructor
        public CustomerRepository()
        {
            _context = new ChatbotEntities();
        }
        public CustomerRepository(ChatbotEntities context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public int SaveCustomer(CustomersTbl customer)
        {
               _context.CustomersTbls.Add(customer);
               return _context.SaveChanges();
        }

        public DbSet<CustomersTbl> GetCustomers()
        {
            return _context.CustomersTbls;
        }

        public CustomersTbl GetByName(string name)
        {
            var customer = (from m in _context.CustomersTbls
                           where m.name == name
                           select m).SingleOrDefault();
            return customer;
        }

        public List<CustomerDetails> GetByRegion(string region)
        {
            return (from cust in _context.CustomersTbls
                            join interest in _context.InterestsTbls on cust.id equals interest.customer_id
                            join monitor in _context.MonitorsTbls on interest.monitor_id equals monitor.monitor_id
                            where cust.region == region
                            select new CustomerDetails
                            {
                                Name = cust.name,
                                Contact = cust.contact,
                                Region = cust.region,
                                Monitor = monitor.monitor_name
                            }).ToList<CustomerDetails>();
        }
        public List<CustomerDetails> GetByDate(DateTime startDate,DateTime endDate)
        {
            return (from cust in _context.CustomersTbls
                    join interest in _context.InterestsTbls on cust.id equals interest.customer_id
                    join monitor in _context.MonitorsTbls on interest.monitor_id equals monitor.monitor_id
                    where (startDate <= interest.timestamp) && (interest.timestamp <= endDate) 
                    select new CustomerDetails
                    {
                        Name = cust.name,
                        Contact = cust.contact,
                        Region = cust.region,
                        Monitor = monitor.monitor_name
                    }).ToList<CustomerDetails>();
        }
        public List<CustomerDetails> GetByDateAndRegion(DateTime startDate, DateTime endDate, string region)
        {
            return (from cust in _context.CustomersTbls
                    join interest in _context.InterestsTbls on cust.id equals interest.customer_id
                    join monitor in _context.MonitorsTbls on interest.monitor_id equals monitor.monitor_id
                    where (startDate <= interest.timestamp) && (interest.timestamp <= endDate) && (cust.region == region)
                    select new CustomerDetails
                    {
                        Name = cust.name,
                        Contact = cust.contact,
                        Region = cust.region,
                        Monitor = monitor.monitor_name
                    }).ToList<CustomerDetails>();
        }
        #endregion
    }
}