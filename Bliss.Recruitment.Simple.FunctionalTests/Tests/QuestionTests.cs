using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bliss.Recruitment.Simple.Api;
using Bliss.Recruitment.Simple.Api.Models.Request;
using Bliss.Recruitment.Simple.Api.Models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Bliss.Recruitment.Simple.FunctionalTests
{
    public class QuestionTests : BaseIntegrationTest
    {
        public QuestionTests(WebAppFixture webAppFixture) : base(webAppFixture)
        {
            
        }

        [Fact]
        public async Task GetByIdShouldReturnOneItem()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await client.GetAsync($"/questions/{id}");

            var responseModel = await response.Content.ReadFromJsonAsync<Question>();
            // Assert
            Assert.NotNull(responseModel);
        }

        [Fact]
        public async Task GetByParamsShouldReturnItems()
        {
            // Arrange
            var skip = 0;
            var take = 5;

            // Act
            var response = await client.GetAsync($"/questions?offset={skip}&limit={take}");

            var responseModel = await response.Content.ReadFromJsonAsync<IEnumerable<Question>>();
            // Assert
            Assert.Equal(responseModel.Count(), take);
        }

        [Fact]
        public async Task GetByParamsWithFilterShouldReturnItemsWichHasThatLanguage()
        {
            // Arrange
            var skip = 0;
            var take = 5;
            var filter = "ruby";

            // Act
            var response = await client.GetAsync($"/questions?offset={skip}&limit={take}&filter={filter}");

            var questions = await response.Content.ReadFromJsonAsync<IEnumerable<Question>>();
            // Assert
            Assert.True(questions.All(question => question.Choices.Any(choice => choice.Description.ToLower() == filter)));
        }

        [Fact]
        public async Task PostQuestionShouldGetId()
        {
            // Arrange
            RegisterQuestionRequestModel questionToRegister = new RegisterQuestionRequestModel()
            {
                Description = "Favourite programming language?",
                ImageUrl = "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                ThumbUrl = "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                Choices = new List<string>() { "Swift", "Python", "Objective-C" },
            };

            // Act
            var response = await client.PostAsJsonAsync($"/questions", questionToRegister);

            var responseModel = await response.Content.ReadFromJsonAsync<Api.Models.Response.Question>();
            // Assert
            Assert.NotNull(responseModel?.QuestionId);
        }

        [Fact]
        public async Task PutQuestionShouldGetChangedItem()
        {
            // Arrange
            var questionToRegister = new RegisterQuestionRequestModel()
            {
                Description = "Language?",
                ImageUrl = "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                ThumbUrl = "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                Choices = new List<string>() { "C#", "Typescript" },
            };

            // Act
            var response = await client.PutAsJsonAsync($"/questions/1", questionToRegister);

            var responseModel = await response.Content.ReadFromJsonAsync<Api.Models.Response.Question>();
            // Assert
            Assert.Equal(questionToRegister.Description, responseModel.Description);
        }

    }
}
