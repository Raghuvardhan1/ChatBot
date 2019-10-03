
using System.Windows;
using System.Windows.Data;

using QuestionAnswerViewModelLib;

namespace ChatbotClientApp
{
    /// <summary>
    /// Interaction logic for ChatbotClient.xaml
    /// </summary>
    public partial class ChatbotClient : Window
    {
        public ChatbotClient()
        {
            QuestionAnswerViewModel.CustomerId  = (Application.Current as App).CustomerId;
            InitializeComponent();
        
        }
    }
}
