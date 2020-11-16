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
