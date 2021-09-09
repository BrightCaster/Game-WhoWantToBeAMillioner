using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Who_wants_to_be_a_Milioner.Models;

namespace Who_wants_to_be_a_Milioner.Repository
{
    public interface IAnswersRepository:IDisposable
    {
        IEnumerable<Answers> GetAnswersList();
        Answers GetAnswers(string id);
    }
}
