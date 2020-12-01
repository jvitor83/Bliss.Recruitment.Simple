using Bliss.Recruitment.Simple.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Data
{
    public interface IQuestionRepository
    {
        Task<Question> Insert(Question question);
        Task<Question> GetById(int id);
        Task<IEnumerable<Question>> GetByParams(int offset, int limit, string filter);
        Task<Question> Update(Question question);
    }
}