using AutoMapper;
using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Core.Models;
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
        protected readonly IValidator<Core.Models.Input.Question> _validator;

        public QuestionService(IQuestionRepository questionRespository, IMapper mapper, IValidator<Core.Models.Input.Question> validator)
        {
            this._questionRepository = questionRespository;
            this._mapper = mapper;
            this._validator = validator;
        }

        public async Task<Core.Models.Output.Question> ChangeQuestion(Core.Models.Input.Question questionToChange)
        {
            await this._validator.ValidateAndThrowAsync(questionToChange);

            Recruitment.Simple.Models.Entities.Question questionToUpdate = this._mapper.Map<Recruitment.Simple.Models.Entities.Question>(questionToChange);

            await this._questionRepository.Update(questionToUpdate);

            Core.Models.Output.Question questionToReturn = this._mapper.Map<Core.Models.Output.Question>(questionToUpdate);

            return questionToReturn;
        }

        public async Task<Core.Models.Output.Question> GetQuestion(int id)
        {
            var model = await this._questionRepository.GetById(id);

            var returnModel = this._mapper.Map<Core.Models.Output.Question>(model);

            return returnModel;
        }

        public async Task<IEnumerable<Core.Models.Output.Question>> GetQuestions(int offset, int limit, string filter)
        {
            var models = await this._questionRepository.GetByParams(offset, limit, filter);

            var returnModels = this._mapper.Map<IEnumerable<Core.Models.Output.Question>>(models);

            return returnModels;
        }

        public async Task<Core.Models.Output.Question> RegisterQuestion(Core.Models.Input.Question questionToRegister)
        {
            await this._validator.ValidateAndThrowAsync(questionToRegister);

            Recruitment.Simple.Models.Entities.Question questionToInsert = this._mapper.Map<Recruitment.Simple.Models.Entities.Question>(questionToRegister);

            await this._questionRepository.Insert(questionToInsert);

            Core.Models.Output.Question questionToReturn = this._mapper.Map<Core.Models.Output.Question>(questionToInsert);

            return questionToReturn;
        }
    }
}
