using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Who_wants_to_be_a_Milioner.Views;
using Who_wants_to_be_a_Milioner.Controllers;
using Who_wants_to_be_a_Milioner.Repository;
using Who_wants_to_be_a_Milioner.Service;


namespace Who_wants_to_be_a_Milioner.Models
{
    public static class Quest
    {
        static string Question = "15";
        public static string QuestionString
        {
            get
            {
                return Question;
            }
            set
            {
                Question = value;
            }
        }
        private static List<int> Add()
        {
            for (int i = 1; i < Convert.ToInt32(Question) + 1; i++)
            {
                step.Add(i);
            }
            return step;
        }
        public static Service.Service service = new Service.Service();
        public static List<string> answers;
        public static List<string> boolAnswers;
        public static string question;
        
        public static int stepbystep = 0;
        public static List<int> Score;
        public static bool Fifty = false;
        public static int cont = 0;
        private static List<int> step = new List<int>();
        private static readonly List<int> s = Add();

        public static List<int> Step = step;
        public static bool randoms = false;
        
        
        


    }
}
