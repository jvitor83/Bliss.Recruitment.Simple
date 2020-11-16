using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Data;
using Bliss.Recruitment.Simple.Data.UnitOfWork;
using Bliss.Recruitment.Simple.Models;
using Bliss.Recruitment.Simple.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Question> ChangeQuestion(int id, string description, string imageUrl, string thumbUrl, ICollection<string> choices)
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

        public async Task<Question> GetQuestion(int id)
        {
            return await this._questionRepository.GetById(id);
        }

        public async Task<IEnumerable<Question>> GetQuestions(int offset, int limit, string filter)
        {
            return await this._questionRepository.GetByParams(offset, limit, filter);
        }

        public async Task<Question> RegisterQuestion(string description, string imageUrl, string thumbUrl, ICollection<string> choices)
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

            await this._questionRepository.Insert(question);

            await this._unitOfWork.Save();

            return question;
        }
    }
}
