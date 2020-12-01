using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bliss.Recruitment.Simple.Api;
using Bliss.Recruitment.Simple.Api.Models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Bliss.Recruitment.Simple.FunctionalTests
{
    public class HealthCheck : BaseIntegrationTest
    {
        public HealthCheck(WebAppFixture webAppFixture) : base(webAppFixture)
        {
        }

        [Fact]
        public async Task HealthCheckShouldReturnOk()
        {
            // Act
            var response = await client.GetAsync("/health");
            
            var responseModel = await response.Content.ReadFromJsonAsync<ResponseModel>();
            // Assert
            Assert.Equal("OK", responseModel.Status);
        }

    }
}
