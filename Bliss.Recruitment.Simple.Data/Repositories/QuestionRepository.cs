using Bliss.Recruitment.Simple.Data.Context;
using Bliss.Recruitment.Simple.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bliss.Recruitment.Simple.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        protected readonly RecruitmentContext _context;
        public QuestionRepository(RecruitmentContext context)
        {
            this._context = context;
        }

        public Question GetById(int id)
        {
            IQueryable<Question> questionsQueryable = this._context.Questions;
            IQueryable<Question> questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices);
            IQueryable<Question> questionsFilteredQueryable = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            Question question = questionsFilteredQueryable.SingleOrDefault();
            return question;
        }

        public void Insert(Question question)
        {
            this._context.Questions.AddAsync(question);
        }
    }
}