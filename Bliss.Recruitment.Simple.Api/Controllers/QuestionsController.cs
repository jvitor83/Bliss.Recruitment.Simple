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
        public QuestionsController(IQuestionService questionService)
        {
            this._questionService = questionService;
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

            Core.Models.Question questionCreated = await this._questionService.RegisterQuestion(
                createQuestionRequestModel.Description,
                createQuestionRequestModel.ImageUrl,
                createQuestionRequestModel.ThumbUrl,
                createQuestionRequestModel.Choices
                );

            return CreatedAtAction(nameof(GetById), new { question_id = questionCreated.QuestionId }, questionCreated);
        }

        [HttpGet("{question_id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int question_id)
        {
            Core.Models.Question question = await this._questionService.GetQuestion(question_id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
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

            IEnumerable<Core.Models.Question> questions = await this._questionService.GetQuestions(offset: requestModel.Offset, limit: requestModel.Limit, filter: requestModel.Filter);

            if (questions == null || questions.Count() == 0)
            {
                return NotFound();
            }

            return Ok(questions);
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

            Core.Models.Question question = await this._questionService.ChangeQuestion(
                question_id, 
                requestModel.Description,
                requestModel.ImageUrl,
                requestModel.ThumbUrl,
                requestModel.Choices
                );

            return CreatedAtAction(nameof(GetById), new { question_id = question.QuestionId }, question);
        }
    }
}