using Bliss.Recruitment.Simple.Data.Context;
using Bliss.Recruitment.Simple.Models;
using Bliss.Recruitment.Simple.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        protected readonly RecruitmentContext _context;
        public QuestionRepository(RecruitmentContext context)
        {
            this._context = context;
        }

        public async Task<Question> GetById(int id)
        {
            IQueryable<Question> questionsQueryable = this._context.Questions;

            #region MyRegion

            //// .AsQueryable();
            //try
            //{
            //    var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices).AsEnumerable();
            //    // var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == 4);
            //    var a = Queryable.Where<Question>(questionsWithChoicesQueryable, question => question.QuestionId == id);

            //    var iQueryable = iEnumerableWhere.AsQueryable();
            //    var a = Queryable.Where<Question>(iQueryable, question => question.QuestionId == id);
            //    var stringResult = iQueryable.ToList();
            //}
            //catch (Exception ex)
            //{

            //}



            //#region NoQuery
            //{
            //    // .AsEnumerable();
            //    {
            //        // .AsQueryable();
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices).AsEnumerable();
            //        //var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = questionsWithChoicesQueryable.AsQueryable();
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // as IQueryable<Question>;
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices).AsEnumerable();
            //        //var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = questionsWithChoicesQueryable as IQueryable<Question>;
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // (IQueryable<Question>)
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices).AsEnumerable();
            //        //var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = (IQueryable<Question>)questionsWithChoicesQueryable;
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}

            ////  as IEnumerable<Question>;
            //{
            //    {
            //        // .AsQueryable();
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices) as IEnumerable<Question>;
            //        //var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = questionsWithChoicesQueryable.AsQueryable();
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // as IQueryable<Question>;
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices) as IEnumerable<Question>;
            //        //var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = questionsWithChoicesQueryable as IQueryable<Question>;
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // (IQueryable<Question>)
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices) as IEnumerable<Question>;
            //        //var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = (IQueryable<Question>)questionsWithChoicesQueryable;
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}

            //// (IEnumerable<Question>)
            //{
            //    {
            //        // .AsQueryable();
            //        var questionsWithChoicesQueryable = (IEnumerable<Question>)questionsQueryable.Include(r => r.Choices);
            //        try
            //        {
            //            var iQueryable = questionsWithChoicesQueryable.AsQueryable();
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // as IQueryable<Question>;
            //        var questionsWithChoicesQueryable = (IEnumerable<Question>)questionsQueryable.Include(r => r.Choices);
            //        try
            //        {
            //            var iQueryable = questionsWithChoicesQueryable as IQueryable<Question>;
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // (IQueryable<Question>)
            //        var questionsWithChoicesQueryable = (IEnumerable<Question>)questionsQueryable.Include(r => r.Choices);
            //        try
            //        {
            //            var iQueryable = (IQueryable<Question>)questionsWithChoicesQueryable;
            //            iQueryable = iQueryable.Where(question => question.QuestionId == id);
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}
            //#endregion

            //#region Where
            //{
            //    // .AsEnumerable();
            //    {
            //        // .AsQueryable();
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices).AsEnumerable();
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = iEnumerableWhere.AsQueryable();
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // as IQueryable<Question>;
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices).AsEnumerable();
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = iEnumerableWhere as IQueryable<Question>;
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // (IQueryable<Question>)
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices).AsEnumerable();
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = (IQueryable<Question>)iEnumerableWhere;
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}

            ////  as IEnumerable<Question>;
            //{
            //    {
            //        // .AsQueryable();
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices) as IEnumerable<Question>;
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = iEnumerableWhere.AsQueryable();
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // as IQueryable<Question>;
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices) as IEnumerable<Question>;
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = iEnumerableWhere as IQueryable<Question>;
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // (IQueryable<Question>)
            //        var questionsWithChoicesQueryable = questionsQueryable.Include(r => r.Choices) as IEnumerable<Question>;
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = (IQueryable<Question>)iEnumerableWhere;
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}

            //// (IEnumerable<Question>)
            //{
            //    {
            //        // .AsQueryable();
            //        var questionsWithChoicesQueryable = (IEnumerable<Question>)questionsQueryable.Include(r => r.Choices);
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = iEnumerableWhere.AsQueryable();
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // as IQueryable<Question>;
            //        var questionsWithChoicesQueryable = (IEnumerable<Question>)questionsQueryable.Include(r => r.Choices);
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = iEnumerableWhere as IQueryable<Question>;
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    {
            //        // (IQueryable<Question>)
            //        var questionsWithChoicesQueryable = (IEnumerable<Question>)questionsQueryable.Include(r => r.Choices);
            //        var iEnumerableWhere = questionsWithChoicesQueryable.Where(question => question.QuestionId == id);
            //        try
            //        {
            //            var iQueryable = (IQueryable<Question>)iEnumerableWhere;
            //            var stringResult = iQueryable.ToList();
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}
            //#endregion 
            #endregion

            IQueryable<Question> questionsFilteredQueryable = questionsQueryable.Include(r => r.Choices).Where(question => question.QuestionId == id);
            Question question = await questionsFilteredQueryable.SingleOrDefaultAsync();
            return question;
        }

        public async Task<IEnumerable<Question>> GetByParams(int offset, int limit, string filter = null)
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
            IEnumerable<Question> result = await questionsFilter.ToListAsync();
            return result;
        }

        public async Task<Question> Insert(Question question)
        {
            var questionEntry = await this._context.Questions.AddAsync(question);

            foreach (var choice in question.Choices)
            {
                choice.QuestionId = question.QuestionId;
                await this._context.Choices.AddAsync(choice);
            }

            await this._context.SaveChangesAsync();

            return questionEntry.Entity;
        }

        public async Task<Question> Update(Question question)
        {
            var existingQuestion = await this.GetById(question.QuestionId);

            this._context.Entry(existingQuestion).CurrentValues.SetValues(question);

            // Remove the old choices
            foreach (var choice in existingQuestion.Choices)
            {
                this._context.Choices.Remove(choice);
            }

            // Add the new choices
            foreach (var choice in question.Choices)
            {
                choice.QuestionId = question.QuestionId;
                this._context.Choices.Add(choice);
            }

            EntityEntry<Question> questionEntry = this._context.Questions.Update(existingQuestion);

            await this._context.SaveChangesAsync();

            return questionEntry.Entity;
        }
    }
}