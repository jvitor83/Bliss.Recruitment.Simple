using AutoFixture;
using AutoFixture.AutoMoq;
using Bliss.Recruitment.Simple.Abstractions.Services;
using Bliss.Recruitment.Simple.Core.BussinessRules;
using Bliss.Recruitment.Simple.Core.Services;
using Bliss.Recruitment.Simple.Data;
using Bliss.Recruitment.Simple.Models.Entities;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Bliss.Recruitment.Simple.Core.UnitTests.Steps
{
    [Binding]
    public class QuestionSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private IQuestionService _questionService;

        private const string EXCEPTION_KEY = "Exception_RegisterQuestion";

        public QuestionSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"A question with only one choice")]
        public void GivenAQuestionWithOnlyOneChoice()
        {
            IFixture fixture = new Fixture();
            // This is to Mock everything dynamically besides the registered (other customizations)
            fixture.Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            // Register the Validator for the Question
            fixture.Customize(new QuestionFixtureCustomization());
            // Arrange
            _questionService = fixture.Create<QuestionService>();
        }

        [When(@"is tried to register")]
        public async Task WhenIsTriedToRegister()
        {
            try
            {
                // Act
                await _questionService.RegisterQuestion(string.Empty, string.Empty, string.Empty, new List<string>() { string.Empty });
            }
            catch (Exception exception)
            {
                this._scenarioContext.Add(EXCEPTION_KEY, exception);
            }
        }

        [Then(@"should gives an exception")]
        public void ThenShouldGivesAnException()
        {
            // Assert
            var exception = this._scenarioContext.Get<Exception>(EXCEPTION_KEY);
            Assert.NotNull(exception);
        }
    }
}
