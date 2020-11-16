using Bliss.Recruitment.Simple.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Recruitment.Simple.Abstractions.Services
{
    public interface IQuestionService
    {
        Question RegisterQuestion(string description, string imageUrl, string thumbUrl, ICollection<string> choices);
        Question GetQuestion(int id);
        IEnumerable<Question> GetQuestions(int offset, int limit, string filter);
    }
}
