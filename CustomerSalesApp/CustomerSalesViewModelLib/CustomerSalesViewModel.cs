using CustomerDetailsDataModelLib;
using MvvmUtilityLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;

namespace CustomerSalesViewModelLib
{
    public class CustomerSalesViewModel
    {
        #region DataMembers

        private ObservableCollection<CustomerDetails> _customers;
        private string _region;
        private DateTime _startDate, _endDate;

        #endregion

        #region Properties

        public ObservableCollection<CustomerDetails> Customers 
        {
            get => _customers;
            set => _customers = value;
        }

        public string Region
        {
            get => _region;
            set => _region = value;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }

        #endregion

        #region Commands

        public ICommand GetCustomers { get; set; }

        #endregion

        #region Initializers

        public CustomerSalesViewModel()
        {
            _customers = new ObservableCollection<CustomerDetails>();

            _startDate = DateTime.Now;
            _endDate = DateTime.Now;

            GetCustomers = new DelegateCommand(
                (object obj) => { this.GetCustomerDetails(); },
                (object obj) => { return true; }
            );
        }

        #endregion

        #region Viewlogic

        public void GetCustomerDetails()
        {
            _customers.Clear();
            UriBuilder builder = new UriBuilder("http://localhost:52413/Customer/GetInterestedCustomersByDateAndRegion");
            builder.Query = "region=" + Region.Split(':')[1].Trim() + "&startDate=" + StartDate.ToString() + "&endDate=" +EndDate.ToString();
            var client = GetHttpClient();
            var response = JsonConvert.DeserializeObject<List<CustomerDetails>>(client.GetAsync(builder.Uri).Result.Content.ReadAsStringAsync().Result);
            foreach (var item in response)
            {
                _customers.Add(item);
            }
        }

        #endregion

        #region HelperFunctions

        private HttpClient GetHttpClient()
        {
            return new HttpClient { BaseAddress = new Uri("http:" + "//localhost:52413") };
        }

        #endregion
    }
}
