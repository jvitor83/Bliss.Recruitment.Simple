using AutoMapper;
using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Data;
using Bliss.Recruitment.Simple.Models.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Core.Services
{
    public class QuestionService : IQuestionService
    {
        protected readonly IQuestionRepository _questionRepository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<Core.Models.Question> _validator;

        public QuestionService(IQuestionRepository questionRespository, IMapper mapper, IValidator<Core.Models.Question> validator)
        {
            this._questionRepository = questionRespository;
            this._mapper = mapper;
            this._validator = validator;
        }

        public async Task<Core.Models.Question> ChangeQuestion(int id, string description, string imageUrl, string thumbUrl, ICollection<string> choices)
        {
            Core.Models.Question question = new Core.Models.Question();
            question.QuestionId = id;
            question.Description = description;
            question.ImageUrl = imageUrl;
            question.ThumbUrl = thumbUrl;
            question.Choices = choices.Select(choice => new Core.Models.Choice()
            {
                Description = choice
            }).ToArray();
            question.PublishedAt = DateTime.Now;

            await this._validator.ValidateAndThrowAsync(question);

            Recruitment.Simple.Models.Entities.Question questionToUpdate = this._mapper.Map<Recruitment.Simple.Models.Entities.Question>(question);

            await this._questionRepository.Update(questionToUpdate);

            Core.Models.Question questionToReturn = this._mapper.Map<Core.Models.Question>(question);

            return questionToReturn;

        }

        public async Task<Core.Models.Question> GetQuestion(int id)
        {
            var model = await this._questionRepository.GetById(id);
            var returnModel = this._mapper.Map<Core.Models.Question>(model);
            return returnModel;
        }

        public async Task<IEnumerable<Core.Models.Question>> GetQuestions(int offset, int limit, string filter)
        {
            var models = await this._questionRepository.GetByParams(offset, limit, filter);
            var returnModels = this._mapper.Map<IEnumerable<Core.Models.Question>>(models);
            return returnModels;
        }

        public async Task<Core.Models.Question> RegisterQuestion(string description, string imageUrl, string thumbUrl, ICollection<string> choices)
        {
            Core.Models.Question question = new Core.Models.Question();
            question.Description = description;
            question.ImageUrl = imageUrl;
            question.ThumbUrl = thumbUrl;
            question.Choices = choices.Select(choice => new Core.Models.Choice()
            {
                Description = choice,
            }).ToArray();
            question.PublishedAt = DateTime.Now;

            await this._validator.ValidateAndThrowAsync(question);

            Recruitment.Simple.Models.Entities.Question questionToInsert = this._mapper.Map<Recruitment.Simple.Models.Entities.Question>(question);

            await this._questionRepository.Insert(questionToInsert);

            Core.Models.Question questionToReturn = this._mapper.Map<Core.Models.Question>(question);

            return questionToReturn;
        }
    }
}
