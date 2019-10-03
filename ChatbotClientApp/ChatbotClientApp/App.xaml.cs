using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChatbotClientApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public int CustomerId { get; set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ChatbotClient client = new ChatbotClient();
            CustomerId = Int32.Parse(e.Args[0]);
            client.Show();


        }
    }
}
