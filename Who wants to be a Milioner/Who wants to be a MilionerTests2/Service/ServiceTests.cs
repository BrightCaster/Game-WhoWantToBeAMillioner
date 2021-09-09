using Microsoft.VisualStudio.TestTools.UnitTesting;
using Who_wants_to_be_a_Milioner.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Who_wants_to_be_a_Milioner.Models;
using Who_wants_to_be_a_Milioner.Controllers;
using Who_wants_to_be_a_Milioner.Repository;

namespace Who_wants_to_be_a_Milioner.Service.Tests
{
    [TestClass()]
    public class ServiceTests
    {
        [TestMethod()]
        public void GetQuestionTest()
        {
            int step = 1;
            Service service = new Service();


            string getQuestion = service.GetQuestion(step.ToString()).Question;
            Assert.AreEqual("Кто первый в мире полетел в космос?", getQuestion);
        }

        [TestMethod()]
        public void GetAnswersListTest()
        {
            Service service = new Service();
            List<string> answers;
            List<string> boolAnswers;
            service.GetAnswersList("1", out answers, out boolAnswers);
            Assert.AreEqual("Алексей Леонов", answers[0]);
            Assert.AreEqual("False     ", boolAnswers[0]);
            service.GetAnswersList("2", out answers, out boolAnswers);
            Assert.AreEqual("Мария Кюри", answers[0]);
            Assert.AreEqual("False     ", boolAnswers[0]);
        }

        [TestMethod()]
        public void GetboolTest()
        {
            Service service = new Service();
            List<string> answers;
            List<string> boolAnswers;
            service.GetAnswersList("1", out answers, out boolAnswers);
            bool tryes = service.Getbool(null, answers, boolAnswers);
            Assert.AreEqual(true,tryes);
            tryes = service.Getbool("Нил Армстронг",answers,boolAnswers);
            Assert.AreEqual(false, tryes);
        }
    }
}