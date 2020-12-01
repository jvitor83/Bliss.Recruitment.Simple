using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bliss.Recruitment.Simple.FunctionalTests
{
    public abstract class BaseIntegrationTest : IClassFixture<WebAppFixture>
    {
        protected readonly HttpClient client;

        public BaseIntegrationTest(WebAppFixture webAppFixture)
        {
            // Arrange
            client = webAppFixture.CreateClient();
        }

    }
}
