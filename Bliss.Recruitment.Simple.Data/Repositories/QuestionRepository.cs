using Bliss.Recruitment.Simple.Data.Context;
using Bliss.Recruitment.Simple.Models;

namespace Bliss.Recruitment.Simple.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        protected readonly RecruitmentContext _context;
        public QuestionRepository(RecruitmentContext context)
        {
            this._context = context;
        }

        public void Insert(Question question)
        {
            this._context.Questions.AddAsync(question);
        }
    }
}