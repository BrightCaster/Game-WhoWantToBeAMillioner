using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Who_wants_to_be_a_Milioner.Models;

namespace Who_wants_to_be_a_Milioner.Repository
{
    public class QuestionRepository :IQuestionRepository
    { 
        private Context db;
        public QuestionRepository()
        {
            this.db = new Context();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) db.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }

        public IEnumerable<Question1> GetQuestionList()
        {
            return db.Question;
        }

        public Question1 GetQuestion(string id)
        {
            return db.Question.FirstOrDefault(p=>p.Id==id);
        }
    }
}
