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
            if(!this.ModelState.IsValid)
            {
                return BadRequest("All fields are mandatory.");
            }

            Question questionCreated = this._questionService.RegisterQuestion(
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
            Question question = this._questionService.GetQuestion(question_id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }
    }
}
