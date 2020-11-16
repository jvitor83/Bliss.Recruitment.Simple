using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Data;
using Bliss.Recruitment.Simple.Data.UnitOfWork;
using Bliss.Recruitment.Simple.Models;
using Bliss.Recruitment.Simple.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss.Recruitment.Simple.Core.Services
{
    public class QuestionService : IQuestionService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRespository, IUnitOfWork unitOfWork)
        {
            this._questionRepository = questionRespository;
            this._unitOfWork = unitOfWork;
        }

        public Question ChangeQuestion(int id, string description, string imageUrl, string thumbUrl, ICollection<string> choices)
        {
            Question question = new Question();
            //question.QuestionId = id;
            question.Description = description;
            question.ImageUrl = imageUrl;
            question.ThumbUrl = thumbUrl;
            question.Choices = choices.Select(choice => new Choice()
            {
                Description = choice
            }).ToArray();
            question.PublishedAt = DateTime.Now;

            this._questionRepository.Update(id, question);

            this._unitOfWork.Save();

            return question;

        }

        public Question GetQuestion(int id)
        {
            return this._questionRepository.GetById(id);
        }

        public IEnumerable<Question> GetQuestions(int offset, int limit, string filter)
        {
            return this._questionRepository.GetByParams(offset, limit, filter);
        }

        public Question RegisterQuestion(string description, string imageUrl, string thumbUrl, ICollection<string> choices)
        {
            Question question = new Question();
            question.Description = description;
            question.ImageUrl = imageUrl;
            question.ThumbUrl = thumbUrl;
            question.Choices = choices.Select(choice => new Choice()
            {
                Description = choice,
            }).ToArray();
            question.PublishedAt = DateTime.Now;

            this._questionRepository.Insert(question);

            this._unitOfWork.Save();

            return question;
        }
    }
}
