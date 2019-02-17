using DnD.Characters.Core.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DnD.IntegrationTests
{
    public class CharacterCreationTests : IClassFixture<WebApplicationFactory<DnD.TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;

        public CharacterCreationTests(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/ManageCharacter")]
        [InlineData("/Privacy")]
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

            Assert.Contains("ManageCharacter", stringResponse);
        }
    }
}
