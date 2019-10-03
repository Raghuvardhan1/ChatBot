using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using chatbotrepo;
using chatbotrepo.DAL;
using chatbotrepo.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class ChatBotControllerTest
    {
        #region Private Fields
        private static IDataFetch<QuestionsTbl> _question;
        private static IDataFetch<MonitorsTbl> _monitor;
        private static IDataFetch<OptionsTbl> _option;
        private static IDataPost _customer;
        #endregion

        #region Default Constructor

        public ChatBotControllerTest()
        {
            _question = new QuestionRepository(new ChatbotEntities());
            _option = new OptionsRepository(new ChatbotEntities());
            _monitor = new MonitorRepository(new ChatbotEntities());
            _customer = new CustomerRepository(new ChatbotEntities());
        }
        #endregion


        #region Test Case Methods
        [TestMethod]
        public void GivenMonitoId_WhenItIsValid_ThenGiveCorrectMonitorName()
        {
            string Actual = "Avalon CL";
            string expected = _monitor.GetById(1).monitor_name;
            Assert.AreEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenMonitoId_WhenItIsValid_ThenGiveCorrectMonitorName2()
        {
            string Actual = "IntelliVue MP5SC";
            string expected = _monitor.GetById(22).monitor_name;
            Assert.AreEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenMonitoId_WhenItIsNotValid_ThenShouldNotGiveCorrecttMonitorName()
        {
            string Actual = "IntelliVue MP5SC";
            string expected = _monitor.GetById(2).monitor_name;
            Assert.AreNotEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenQuestionId_WhenItIsValid_ThenDisplayCorrectQuestion()
        {
            string Actual = "Do you want a monitor with cable or cableless?";
            string expected = _question.GetById(2).question;
            Assert.AreEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenQuestionIdAndOptionId_WhenItIsValid_ThenReturnNextQuestionId()
        {
            int Actual = 13;
            int expected = _option.FindWhere(12, 1).link_id;
            Assert.AreEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenQuestionIdAndOptionId_WhenItIsNotValid_ThenShouldNotReturnNextQuestionId()
        {
            int Actual = 3;
            int expected = _option.FindWhere(12, 1).link_id;
            Assert.AreNotEqual(Actual, expected);
        }


        [TestMethod]
        public void GivenQuestionIdAndOptionId_WhenItIsValid_ThenReturnCorrespondingMonitorId()
        {
             int Actual = 19;
            int expected = _option.FindWhere(12, 5).monitor_id;
            Assert.AreEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenQuestionIdAndOptionId_WhenItIsNotValid_ThenShouldNotReturnCorrespondingMonitorId()
        {
            int Actual = 1;
            int expected = _option.FindWhere(12, 5).monitor_id;
            Assert.AreNotEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenQuestionIdAndOptionId_WhenItIsValid_ThenReturnCorrespondingMonitorId2()
        {
            int Actual = 10;
            int expected = _option.FindWhere(11, 3).monitor_id;
            Assert.AreEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenQuestionIdAndOptionId_WhenItIsValid_ThenReturnCorrespondingNextQuestionId()
        {
            int Actual = 13;
            int expected = _option.FindWhere(12, 2).link_id;
            Assert.AreNotEqual(Actual, expected);
        }

        [TestMethod]
        public void GivenQuestionId_WhenItIsValid_ThenDisplayCorrectQuestion2()
        {
            string Actual = "Select one of the required features from the following options.";
            string expected = _question.GetById(14).question;
            Assert.AreEqual(Actual, expected);
        }

        ChatbotController chatbot = new ChatbotController();

        [TestMethod]
        public void GivenQuestionId1_WhenItIsValid_ThenDisplayCorrectQuestion2()
        {
            string Actual = "What is the basic requirement of your monitor?" + Environment.NewLine + " 1. Maternal and Fetal " + Environment.NewLine + " 2. Vital Signs" + Environment.NewLine + " 3. Bedside Patient Monitor" + Environment.NewLine + " 4. Central Monitoring System" + Environment.NewLine + " 5. IntelliVue(serves a wide range of care environment)";
            string expected = chatbot.Get();
            Assert.AreNotEqual(expected, Actual);
        }

        
        [TestMethod]
        public void Given_QuestionId_1_and_OptionId_1_Return_LinkId_2()
        {
            int expected = chatbot.GetLink(new OptionsTbl { question_id = 1, option_id = 1 });
            int actual = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_LinkId_4_Return_Question_And_Options_with_Id_4()
        {
            string expected = chatbot.FetchQuestion(new OptionsTbl { link_id = 4 });
            string actual = "Do you want video and audio interface?" + Environment.NewLine + "1.Yes" + Environment.NewLine + "2.No\n";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void Given_QId_And_OptId_fetch_MonitorName()
        {
            string expected = chatbot.GetMonitorName(chatbot.MonitorFetch(new  OptionsTbl { option_id = 3, question_id = 12 }));
            string actual = "IntelliVue GS";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenQuestionId_WhenOptionRepoGetById_ThenNotImplementedException()
        {
            var expected = _option.GetById(1);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenQuestionId_WhenOptionRepoDataFetch_ThenNotImplementedException()
        {
            var expected = _option.DataFetch(1);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenQuestionIdAndOptionId_WhenOptionRepoDataFetch_ThenNotImplementedException()
        {
            var expected = _option.DataFetch(1,1);
        }


        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenIds_ForQuestionRepoFindWhere_ThenNotImplementedException()
        {
            var expected = _question.FindWhere(1,1);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenQuestionId_ForQuestionRepoDataFetch_ThenNotImplementedException()
        {
            var expected = _question.DataFetch(1);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenIds_ForQuestionRepoDataFetch_ThenNotImplementedException()
        {
            var expected = _question.DataFetch(1, 1);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenIds_WhenMonitorRepoFindWhere_ThenNotImplementedException()
        {
            var expected = _monitor.FindWhere(1, 1);
        }

        [TestMethod]
        public void GivenId_WhenMonitorRepoDataFetch_ThenReturnMonitor()
        {
            var expected = _monitor.DataFetch(1);
            Assert.AreEqual(1,expected.Count);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NotImplementedException))]
        public void GivenIds_WhenMonitorRepoDataFetch_ThenNotImplementedException()
        {
            var expected = _monitor.DataFetch(1, 1);
        }

        [TestMethod]
        public void Given_CustomerObject_WhenSaveCustomer_ThenReturnSuccess()
        {
            CustomerController customerRef = new CustomerController();
            CustomersTbl customer = new CustomersTbl();
            customer.name = "Test name From Controller";
            customer.contact = 9090909090;
            customer.region = "Bangalore";
            string expected = "Success";
            string actual = customerRef.SaveCustomer(customer);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_CustomerObject_WhenSaveCustomer_ThenReturnInt()
        {
            CustomersTbl customer=new CustomersTbl();
            customer.name = "Test name";
            customer.contact = 9090909090;
            customer.region = "Bangalore";
            int value = _customer.SaveCustomer(customer);
            Assert.IsTrue(value > 0, "return value is greater than zero");
        }
        #endregion
    }
}