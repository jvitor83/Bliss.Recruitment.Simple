using Bliss.Recruitment.Simple.Core.Models;
using Bliss.Recruitment.Simple.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<Question> RegisterQuestion(string description, string imageUrl, string thumbUrl, ICollection<string> choices);
        Task<Question> GetQuestion(int id);
        Task<IEnumerable<Question>> GetQuestions(int offset, int limit, string filter);
        Task<Question> ChangeQuestion(int id, string description, string imageUrl, string thumbUrl, ICollection<string> choices);
    }
}
