namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.User.Commands.Update;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Update.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class UpdateUserEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenAuthenticatedUserAndInvalidUserRequest_WhenUpdateUser_ThenReturnsBadRequestStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("harold.shepard@gmail.com", "#Password4Harold");
		var userId = Guid.Parse("F1B8EE24-D578-4733-95E0-0B627F343F96");
		var request = new UpdateUserEndpointRequest
		{
			User = new UpdateUserEndpointUserRequest
			{
				Email = "harold.shepard@gmail.com",
				FirstName = "",
				LastName = ""
			}
		};

		var response = await PutAsync(UpdateUserEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}

	[Test]
	public async Task GivenAuthenticatedUserAndValidUserRequest_WhenUpdateUser_ThenReturnsNoContentStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("harold.shepard@gmail.com", "#Password4Harold");
		var userId = Guid.Parse("F1B8EE24-D578-4733-95E0-0B627F343F96");
		var request = new UpdateUserEndpointRequest
		{
			User = new UpdateUserEndpointUserRequest
			{
				Email = "harold.shepard@gmail.com",
				FirstName = "Harold Jr.",
				LastName = "Smith"
			}
		};

		var response = await PutAsync(UpdateUserEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
	}

	[Test]
	public async Task GivenAuthenticatedUserAndValidUserRequest_WhenUpdateUser_ThenUserIsUpdatedInDatabase()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("harold.shepard@gmail.com", "#Password4Harold");
		var userId = Guid.Parse("F1B8EE24-D578-4733-95E0-0B627F343F96");
		var request = new UpdateUserEndpointRequest
		{
			User = new UpdateUserEndpointUserRequest
			{
				Email = "harold.shepard@gmail.com",
				FirstName = "Harold Jr.",
				LastName = "Smith"
			}
		};

		await PutAsync(UpdateUserEndpointTest.BuildUrl(userId), token, request);
		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		var user = await databaseContext.Users.FindAsync(userId);

		Assert.That(user, Is.Not.Null);
		Assert.Multiple(() =>
		{
			Assert.That(user.UserId, Is.EqualTo(userId));
			Assert.That(user.Email, Is.EqualTo(request.User.Email));
			Assert.That(user.Password, Is.EqualTo("$2a$12$AMeRQh0/NQbdkyi/C7rFTeDiWT6aitP2AtPnoui7lO3sDXjG6Q6GC"));
			Assert.That(user.FirstName, Is.EqualTo(request.User.FirstName));
			Assert.That(user.LastName, Is.EqualTo(request.User.LastName));
		});
	}

	private async Task<string> GetAuthenticationTokenAsync(string email, string password)
	{
		var request = new LoginUserEndpointRequest
		{
			Email = email,
			Password = password
		};

		var response = await PostAsync($"{UserEndpointsMapper.Prefix}/login", null, request);
		var content = await response.Content.ReadFromJsonAsync<LoginUserEndpointResponse>();

		Assert.That(content, Is.Not.Null);

		return content.Token;
	}

	private static string BuildUrl(Guid userId)
	{
		return $"{UserEndpointsMapper.Prefix}/{userId}";
	}
}