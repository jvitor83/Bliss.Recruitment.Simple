using Bliss.Recruitment.Simple.Models;
using System.Collections.Generic;

namespace Bliss.Recruitment.Simple.Data
{
    public interface IQuestionRepository
    {
        void Insert(Question question);
        Question GetById(int id);
        IEnumerable<Question> GetByParams(int offset, int limit, string filter);
    }
}