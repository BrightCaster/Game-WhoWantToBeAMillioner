using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Who_wants_to_be_a_Milioner.Models;
using Microsoft.EntityFrameworkCore;
using Who_wants_to_be_a_Milioner.Views;

namespace Who_wants_to_be_a_Milioner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Service.Service Service;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.Service = new Service.Service();
        }
        
        
        [HttpGet]
        public IActionResult Index(string started, string options)
        {
            
            ViewData["AmountQuest"] = Quest.QuestionString;

            if (started == "Начать игру")
            {
                switch (Convert.ToInt32(Quest.QuestionString))
                {
                    case 15:Quest.Score = Service.Score15;
                        break;
                    case 10:Quest.Score = Service.Score10;
                        break;
                    case 5:Quest.Score = Service.Score5;
                        break;
                }
                return Redirect("/Home/Start");
            }
                
            else if (options=="Настройки")
                return Redirect("/Home/Options");
            return View();
        }
        [HttpGet]
        public IActionResult Start(string BackToStart, string thisAnswer, string fifty)
        {
            
            if (BackToStart == "Назад")
            {
                Quest.Fifty = false;
                Quest.stepbystep = 0;
                Quest.cont = 0;
                Quest.randoms = false;
                return Redirect("/Home/Index");
            }
            else
            {
                if (Quest.randoms == false)
                {
                    Quest.Step = Service.Random(Quest.Step);
                    Quest.randoms = true;
                }
                    
                if (fifty == "50/50" && Quest.Fifty==false)
                {
                    Quest.stepbystep -= 1;
                    Quest.Fifty = true;
                }
                if (Quest.stepbystep < Convert.ToInt32(Quest.QuestionString))
                {

                    ViewBag.Score = Quest.Score[Quest.stepbystep];
                    if (!Service.Getbool(thisAnswer, Quest.answers, Quest.boolAnswers))
                    {
                        ViewBag.Question1 = "Вы проиграли";
                        ViewBag.Score = Quest.Score[Quest.stepbystep-1];
                        Quest.stepbystep = 0;
                        return View();
                    }
                    else
                    {
                        if (Quest.Fifty && Quest.cont==0)
                        {
                            int indexfalse = Service.RandomBool(Quest.boolAnswers);
                            ViewBag.Question1 = Quest.question;
                            switch (indexfalse)
                            {
                                case 0:ViewBag.Answer1 = Quest.answers[indexfalse];
                                    break;
                                case 1:ViewBag.Answer2 = Quest.answers[indexfalse];
                                    break;
                                case 2:ViewBag.Answer3 = Quest.answers[indexfalse];
                                    break;
                                case 3:ViewBag.Answer4 = Quest.answers[indexfalse];
                                    break;
                            }
                            int trues=5;
                            for (int i = 0; i < Quest.boolAnswers.Count; i++)
                            {
                                string s = Quest.boolAnswers[i].Remove(4);
                                if (s == "True")
                                    trues = i;
                            }
                            switch (trues)
                            {
                                case 0:
                                    ViewBag.Answer1 = Quest.answers[trues];
                                    break;
                                case 1:
                                    ViewBag.Answer2 = Quest.answers[trues];
                                    break;
                                case 2:
                                    ViewBag.Answer3 = Quest.answers[trues];
                                    break;
                                case 3:
                                    ViewBag.Answer4 = Quest.answers[trues];
                                    break;
                            }
                            Quest.cont = 1;
                            Quest.stepbystep++;
                            return View();
                        }
                        else
                        {
                            Quest.question = Service.GetQuestion(Quest.Step[Quest.stepbystep].ToString()).Question;
                            Service.GetAnswersList(Quest.Step[Quest.stepbystep].ToString(), out Quest.answers, out Quest.boolAnswers);
                            Service.Randoms(Quest.answers, Quest.boolAnswers, out Quest.answers, out Quest.boolAnswers);
                        }
                        ViewBag.Question1 = Quest.question;
                        ViewBag.Answer1 = Quest.answers[0];
                        ViewBag.Answer2 = Quest.answers[1];
                        ViewBag.Answer3 = Quest.answers[2];
                        ViewBag.Answer4 = Quest.answers[3];
                        Quest.stepbystep++; ;
                    }
                }
                else
                {
                    ViewBag.Score = Quest.Score[Quest.stepbystep];
                    Quest.stepbystep = 0;
                    ViewBag.Question1 = "Вы выйграли";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Options(string BackToStart, string take)
        {
            if (BackToStart == "Назад" && take!=null)
            {
                Quest.QuestionString = take;
                return Redirect("/Home/Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
