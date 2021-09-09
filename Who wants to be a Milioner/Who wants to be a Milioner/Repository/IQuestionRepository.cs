using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Who_wants_to_be_a_Milioner.Models;

namespace Who_wants_to_be_a_Milioner.Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<Question1> GetQuestionList();
        Question1 GetQuestion(string id);
    }
}
