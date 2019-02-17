using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace DnD.FunctionalTests
{
    public class HomePageTests : IClassFixture<WebApplicationFactory<DnD.TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;

        public HomePageTests(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }
    
        [Theory]
        [InlineData("/")]
        [InlineData("/Privacy")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
