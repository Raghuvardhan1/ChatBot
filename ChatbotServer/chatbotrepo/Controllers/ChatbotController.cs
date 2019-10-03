using chatbotrepo.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace chatbotrepo.Controllers
{
    public class ChatbotController : Controller
    {
        #region Private Fields
        private IDataFetch<QuestionsTbl> _question ;
        private IDataFetch<MonitorsTbl> _monitor;
        private IDataFetch<OptionsTbl> _option;
        #endregion

        #region Default Constructor
        public ChatbotController()
        {
            _question = new QuestionRepository(new ChatbotEntities());
            _option = new OptionsRepository(new ChatbotEntities());
            _monitor = new MonitorRepository(new ChatbotEntities());
        }
        #endregion

        #region Methods
        [HttpGet]
        public string Get()
        {
            var QuesRow = _question.GetById(1);
            var  list = QuesRow.OptionsTbls.ToList();
            var options = new Dictionary<int, string>();
            options.Add(0, QuesRow.question);
            foreach (OptionsTbl opt in list)
            {
                options.Add(opt.option_id, opt.option);
            }
            return JsonConvert.SerializeObject(options);
        }

        [HttpPost]
        public int GetLink(OptionsTbl options)
        {
            var OptRow = _option.FindWhere(options.question_id, options.option_id);
            return OptRow.link_id;
        }

        public string FetchQuestion(OptionsTbl o)
        {
            var QuesRow = _question.GetById(o.link_id);
            var list = QuesRow.OptionsTbls.ToList();
            var options = new Dictionary<int, string>();
            options.Add(0, QuesRow.question);
            foreach (OptionsTbl opt in list)
            {
                options.Add(opt.option_id, opt.option);
            }
            return JsonConvert.SerializeObject(options);
        }

        [System.Web.Http.HttpPost]
        public int MonitorFetch(OptionsTbl o)
        {
            var m = _option.FindWhere(o.question_id, o.option_id);
            return m.monitor_id;
        }

        [System.Web.Mvc.HttpGet]
        public string GetMonitorName(int id)
        {
            return _monitor.GetById(id).monitor_name;
        }

        #endregion
    }
}
