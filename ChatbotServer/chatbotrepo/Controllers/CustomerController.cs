using chatbotrepo.DAL;
using chatbotrepo.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace chatbotrepo.Controllers
{
    public class CustomerController : Controller
    {

        #region Private Fields
        private CustomerRepository _customer;
        private CustomerOrdersRepository _customerOrders;
        private InterestedCustomersRepository _interestedCustomers;
        #endregion

        #region Default Constructor
        public CustomerController()
        {
            _customer = new CustomerRepository(new ChatbotEntities());
            _customerOrders = new CustomerOrdersRepository();
            _interestedCustomers = new InterestedCustomersRepository();
        }
        #endregion

        #region Methods
        [System.Web.Http.HttpPost]
        public string SaveCustomer(CustomersTbl customer)
        {
            if (customer.name != null)
            {
                _customer.SaveCustomer(customer);
                return "Success";
            }
            return "Failure";
        }

        [System.Web.Mvc.HttpGet]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(_customer.GetCustomers().ToList<CustomersTbl>());
        }

        [System.Web.Mvc.HttpGet]
        public string GetByName(string name)
        {
            return JsonConvert.SerializeObject(_customer.GetByName(name), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [System.Web.Mvc.HttpGet]
        public string GetInterestedCustomers(string region)
        {
            return JsonConvert.SerializeObject(_customer.GetByRegion(region));
        }
        [System.Web.Mvc.HttpGet]
        public string GetInterestedCustomersByDate(DateTime startDate, DateTime endDate)
        {
            return JsonConvert.SerializeObject(_customer.GetByDate(startDate,endDate));
        }
        [System.Web.Mvc.HttpGet]
        public string GetInterestedCustomersByDateAndRegion(DateTime startDate, DateTime endDate,string region)
        {
            return JsonConvert.SerializeObject(_customer.GetByDateAndRegion(startDate, endDate,region));
        }
        [System.Web.Mvc.HttpGet]
        public string GetCustomerOrders()
        {
            return JsonConvert.SerializeObject(_customerOrders.GetAll().ToList<OrdersTbl>());
        }

        [System.Web.Mvc.HttpPost]
        public void AddInterestedCustomer(InterestsTbl interests)
        {
            _interestedCustomers.AddOne(interests);
        }

        [System.Web.Mvc.HttpPost]
        public void AddCustomerOrder(OrdersTbl order)
        {
            _customerOrders.AddOne(order);
        }

        [System.Web.Mvc.HttpGet]
        public int? GetExistingCustomerInterestMonitor(int id)
        {
            return _interestedCustomers.GetMonitorById(id);
            

        }
        [System.Web.Mvc.HttpGet]
        public string GetExistingCustomerOrderMonitor(int id)
        {
            return _customerOrders.GetMonitorById(id);
        }

        
        #endregion
    }
}
