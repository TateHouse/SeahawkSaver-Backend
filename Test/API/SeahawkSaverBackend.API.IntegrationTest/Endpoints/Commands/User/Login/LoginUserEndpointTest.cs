namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Commands.User.Login;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class LoginUserEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenEmailThatDoesNotExist_WhenLoginUser_ThenReturnsResponseWithNotFoundStatus()
	{
		var request = new LoginUserEndpointRequest
		{
			Email = "",
			Password = ""
		};

		var response = await PostAsync($"{UserEndpointsMapper.Prefix}/login", request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}

	[Test]
	public async Task GivenEmailThatExistsAndInvalidPassword_WhenLoginUser_ThenReturnsResponseWithUnauthorizedStatus()
	{
		await SeedDatabaseAsync();

		var request = new LoginUserEndpointRequest
		{
			Email = "peter.keller@gmail.com",
			Password = "#Password4Testing"
		};

		var response = await PostAsync($"{UserEndpointsMapper.Prefix}/login", request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenEmailThatExistsAndValidPassword_WhenLoginUser_ThenReturnsResponseWithOkStatus()
	{
		await SeedDatabaseAsync();

		var request = new LoginUserEndpointRequest
		{
			Email = "peter.keller@gmail.com",
			Password = "#Password4Peter"
		};

		var response = await PostAsync($"{UserEndpointsMapper.Prefix}/login", request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
	}

	[Test]
	public async Task GivenEmailThatExistsAndValidPassword_WhenLoginUser_ThenReturnsResponseWithAuthenticationTokenAndUser()
	{
		await SeedDatabaseAsync();

		var request = new LoginUserEndpointRequest
		{
			Email = "peter.keller@gmail.com",
			Password = "#Password4Peter"
		};

		var response = await PostAsync($"{UserEndpointsMapper.Prefix}/login", request);
		var content = await response.Content.ReadFromJsonAsync<LoginUserEndpointResponse>();

		Assert.That(content, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(content.Token, Is.Not.Empty);
            Assert.That(content.User.UserId, Is.EqualTo(Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B")));
            Assert.That(content.User.Email, Is.EqualTo("peter.keller@gmail.com"));
        });
    }
}