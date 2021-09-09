using System.Collections.Generic;
using System.Linq;
using Who_wants_to_be_a_Milioner.Models;

namespace Who_wants_to_be_a_Milioner.Repository
{
    public class AnswersRepository : IAnswersRepository
    {
        private Context db;
        public AnswersRepository()
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

        public Answers GetAnswers(string id)
        {
            return db.Answers.FirstOrDefault(p=>p.key==id);
        }

        public IEnumerable<Answers> GetAnswersList()
        {
            return db.Answers;
        }
    }
}
