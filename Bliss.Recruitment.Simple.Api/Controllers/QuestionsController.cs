using Bliss.Recruitment.Simple.Abstractions;
using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Api.Models.Request;
using Bliss.Recruitment.Simple.Api.Models.Response;
using Bliss.Recruitment.Simple.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        protected readonly IQuestionService _questionService;
        protected readonly IMapper _mapper;
        public QuestionsController(IQuestionService questionService, Abstractions.IMapper mapper)
        {
            this._questionService = questionService;
            this._mapper = mapper;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Question), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] RegisterQuestionRequestModel createQuestionRequestModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("All fields are mandatory.");
            }

            Core.Models.Input.Question question = this._mapper.Map<Core.Models.Input.Question>(createQuestionRequestModel);

            Core.Models.Output.Question questionCreated = await this._questionService.RegisterQuestion(question);

            Models.Response.Question questionToReturn = this._mapper.Map<Models.Response.Question>(questionCreated);

            return CreatedAtAction(nameof(GetById), new { question_id = questionToReturn.QuestionId }, questionToReturn);
        }

        [HttpGet("{question_id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int question_id)
        {
            Core.Models.Output.Question question = await this._questionService.GetQuestion(question_id);

            if (question == null)
            {
                return NotFound();
            }

            Models.Response.Question questionToReturn = this._mapper.Map<Models.Response.Question>(question);

            return Ok(questionToReturn);
        }


        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<Question>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetQuestionsWithParamsRequestModel requestModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest($"The fields '${nameof(GetQuestionsWithParamsRequestModel.Offset)}' and '${nameof(GetQuestionsWithParamsRequestModel.Limit)}' are mandatory.");
            }

            IEnumerable<Core.Models.Output.Question> questions = await this._questionService.GetQuestions(
                offset: requestModel.Offset, 
                limit: requestModel.Limit, 
                filter: requestModel.Filter
                );

            if (questions == null || questions.Count() == 0)
            {
                return NotFound();
            }

            IEnumerable<Models.Response.Question> questionToReturn = this._mapper.Map<IEnumerable<Models.Response.Question>>(questions);

            return Ok(questionToReturn);
        }


        [HttpPut("{question_id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Question), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int question_id, [FromBody] RegisterQuestionRequestModel requestModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("All fields are mandatory.");
            }

            requestModel.QuestionId = question_id;

            Core.Models.Input.Question questionToChange = this._mapper.Map<Core.Models.Input.Question>(requestModel);

            Core.Models.Output.Question questionChanged = await this._questionService.ChangeQuestion(questionToChange);

            Models.Response.Question questionToReturn = this._mapper.Map<Models.Response.Question>(questionChanged);

            return CreatedAtAction(nameof(GetById), new { question_id = questionToReturn.QuestionId }, questionToReturn);
        }
    }
}