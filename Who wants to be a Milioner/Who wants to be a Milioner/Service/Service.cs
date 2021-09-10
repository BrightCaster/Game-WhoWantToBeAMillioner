using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Who_wants_to_be_a_Milioner.Repository;
using Who_wants_to_be_a_Milioner.Models;

namespace Who_wants_to_be_a_Milioner.Service
{
    public class Service
    {
        public List<int> Score5 = new List<int>() {0,62500,125000,250000,500000,1000000 };
        public List<int> Score10 = new List<int>() {0,10000,30000,50000,75000,100000,1250000,300000,550000,800000,1000000 };
        public List<int> Score15 = new List<int>() {0,100,200,300,500,1000,2000,4000,8000,16000,32000,64000,128000,250000,500000,1000000 };

        private AnswersRepository AnswersRepository;
        private QuestionRepository QuestionRepository;
        public Service()
        {
            this.AnswersRepository = new AnswersRepository();
            this.QuestionRepository = new QuestionRepository();
        }
        public void GetAnswersList(string idQ, out List<string> Answers, out List<string> BoolAnswers)
        {
            List<string> answers = new List<string>();
            List<string> boolAnswers = new List<string>();
            foreach (var obj in AnswersRepository.GetAnswersList())
            {
                if (Convert.ToInt32(idQ) == Convert.ToInt32(obj.key))
                {
                    answers.Add(obj.answers);
                    boolAnswers.Add(obj.Bool);
                }
            }
            Answers = answers;
            BoolAnswers = boolAnswers;
        }
        public Question1 GetQuestion(string id)
        {
            return QuestionRepository.GetQuestion(id);
        }
        public bool Getbool(string thisAnswer, List<string> Answers, List<string> BoolAnswer)
        {
            if (thisAnswer == null) return true;
            int Length = Answers.Count;
            for (int i = 0; i < Length; i++)
            {
                if (thisAnswer == Answers[i])
                    return Convert.ToBoolean(BoolAnswer[i].ToLower());
            }
            return false;
        }
        public void Randoms(List<string> answers, List<string> boolAnswer, out List<string> Answers, out List<string> BoolAnswer)
        {
            Random RND = new Random();
            int icount = RND.Next(1, answers.Count);
            for (int i = 0; i < answers.Count; i++)
            {
                if (icount == i) continue;
                string tmp = answers[i];
                answers[i] = answers[icount];
                answers[icount] = tmp;
                string tmp2 = boolAnswer[i];
                boolAnswer[i] = boolAnswer[icount];
                boolAnswer[icount] = tmp2;
            }
            Answers = answers;
            BoolAnswer = boolAnswer;
        }
        public int RandomBool(List<string> boolAnswer)
        {
            Random RND = new Random();
            int cont = RND.Next(0, 3);
            string s = boolAnswer[cont].Remove(5);
            if (s == "False")
                return cont;
            else if(s=="True ")
                cont+=1;
            return cont;
        }
        public List<int> Random(List<int> list)
        {
            Random random = new Random();
            int key;
            int rnint;
            int count = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                rnint = list[0];
                key = random.Next(0, list[list.Count - 1]);
                if (rnint == list[key])
                    continue;
                list.RemoveAt(0);
                list.Insert(key, rnint);
                count++;
            }
            return list;
        }

    }
}
