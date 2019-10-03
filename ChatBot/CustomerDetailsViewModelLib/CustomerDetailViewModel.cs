using CustomesDataModelLib;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Input;
using MVVMUtilityLib;
using Newtonsoft.Json;
using System.Windows;
using System.IO;

namespace CustomerDetailsViewModelLib
{
    public class CustomerDetailViewModel
    {
        #region Declarations
        CustomersDataModel _customerRef = new CustomersDataModel();
        private ICommand _addCustomerCommand;
        private HttpClient _client;
        #endregion
            
        #region Properties

        public String Name
        {
            get => _customerRef.Name;
            set => _customerRef.Name = value;
        }

        public int Id
        {
            get => _customerRef.Id;
            set => _customerRef.Id = value;

        }

        public long Contact
        {
            get => _customerRef.Contact;
            set => _customerRef.Contact = value;
        }

        public string Region { get=>_customerRef.Region; set=>_customerRef.Region=value; }

        public ICommand AddNewCustomer 
        {
            get => _addCustomerCommand;
            set => _addCustomerCommand = value;
        }

        public string OrdersMonitorMessage { get; set; }
        public string InterestsMonitorMessage { get; set; }

        #endregion

        #region ViewLogic

        public void AddCustomer()
        {

	        GetClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.PostAsJsonAsync<CustomersDataModel>($"http://localhost:52413/Customer/SaveCustomer", _customerRef);

            var cwd = Directory.GetCurrentDirectory();
            cwd += "\\..\\..\\..\\..\\ChatbotClientApp\\ChatbotClientApp\\bin\\Debug\\ChatbotClientApp.exe";
            Process.Start(cwd, _customerRef.Id.ToString());
        }

        public void GetClient()
        {
	       _client = new HttpClient { BaseAddress = new Uri("http:" + "//localhost:52413") };
	        
        }
	

        public void CheckCustomer()
        {
	        GetClient();
            UriBuilder builder = new UriBuilder($"http://localhost:52413/Customer/GetByName");
            builder.Query = "name="+_customerRef.Name;
            var customer = JsonConvert.DeserializeObject<CustomersDataModel>(_client.GetAsync(builder.Uri).Result.Content.ReadAsStringAsync().Result);
            if (customer==null)
            {
                AddCustomer();
            }
            else
            {
                _customerRef.Id = customer.Id;
                ExistingCustomer();
            }
        }

        public void ExistingCustomer()
        {
           GetClient();
            UriBuilder builder = new UriBuilder($"http://localhost:52413/Customer/GetExistingCustomerOrderMonitor");
            builder.Query = "id=" + _customerRef.Id;
            var monitorId = _client.GetAsync(builder.Uri).Result.Content.ReadAsStringAsync().Result;
            MessageBoxResult messageBoxResult = MessageBox.Show($" Your Previous buy was {monitorId}. Would you like to buy the same monitor?", "Re-buy Window", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                //order
            }
            else
            {
                var cwd = Directory.GetCurrentDirectory();
                cwd += "\\..\\..\\..\\..\\ChatbotClientApp\\ChatbotClientApp\\bin\\Debug\\ChatbotClientApp.exe";
                Process.Start(cwd, _customerRef.Id.ToString());
            }
        }
	

        #endregion

        #region Initializers

        public CustomerDetailViewModel()
        {
            AddNewCustomer = new DelegateCommand((object obj) => { this.CheckCustomer(); }, (object obj) => { return true; });

        }


        #endregion
    }
}
