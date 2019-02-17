using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace DnD.FunctionalTests
{
    public class CharacterCreationTests : IClassFixture<WebApplicationFactory<DnD.TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;

        public CharacterCreationTests(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        
        [Theory]
        [InlineData("/ChatacterList")]
        [InlineData("/ManageCharacter")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task ReturnsManageCharacterPageListing()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/ManageCharacter");
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("Manage Character", stringResponse);
        }
    }
}
