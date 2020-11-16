using Bliss.Recruitment.Simple.Data.Context;
using Bliss.Recruitment.Simple.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Question> GetByParams(int offset, int limit, string filter)
        {
            IQueryable<Question> questionsQueryable = this._context.Questions;
            IQueryable<Question> questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices);
            // TODO: Refactory to be Specification Pattern
            // if the filter is informed
            if (!String.IsNullOrWhiteSpace(filter))
            {
                string filterToApply = filter.ToLower();
                // apply the where expression
                questionsWithChoicesQueryable = questionsWithChoicesQueryable.Where(
                    question => question.Description.ToLower().Contains(filterToApply)
                    || question.Choices.Any(r => r.Description.ToLower().Contains(filterToApply))
                    );
            }
            IQueryable<Question> questionsFilter = questionsWithChoicesQueryable.Skip(offset).Take(limit);
            IEnumerable<Question> result = questionsFilter.ToList();
            return result;
        }

        public void Insert(Question question)
        {
            this._context.Questions.AddAsync(question);
        }
    }
}