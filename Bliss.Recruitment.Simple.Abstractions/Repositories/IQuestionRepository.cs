using Bliss.Recruitment.Simple.Models;

namespace Bliss.Recruitment.Simple.Data
{
    public interface IQuestionRepository
    {
        void Insert(Question question);
        Question GetById(int id);
    }
}