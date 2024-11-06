namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Saving.Commands.Delete;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.API.Endpoints.Saving;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class DeleteSavingEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenNoBearerToken_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var queryParameters = new Dictionary<string, string>
		{
			{ "savingId", "CC15E589-CE4D-419C-90F5-73B4181892FF" }
		};

		var response = await DeleteAsync(DeleteSavingEndpointTest.BuildUrl(userId), null, queryParameters);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenUserIdInRouteThatDoesNotMatchAuthenticatedUser_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		await SeedDatabaseAsync();
		var token = await GetAuthenticationTokenAsync("harold.shepard@gmail.com", "#Password4Harold");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var queryParameters = new Dictionary<string, string>
		{
			{ "savingId", "CC15E589-CE4D-419C-90F5-73B4181892FF" }
		};

		var response = await DeleteAsync(DeleteSavingEndpointTest.BuildUrl(userId), token, queryParameters);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndSavingIdThatDoesNotExist_WhenDeleteSaving_ThenReturnsNotFoundStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var queryParameters = new Dictionary<string, string>
		{
			{ "savingId", "1DB238F7-00AF-40E0-8CEC-B62764C0ED8C" }
		};

		var response = await DeleteAsync(DeleteSavingEndpointTest.BuildUrl(userId), token, queryParameters);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndSavingIdThatExists_WhenDeleteSaving_ThenReturnsNoContentStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var queryParameters = new Dictionary<string, string>
		{
			{ "savingId", "AF476108-6951-4246-BC4E-35EE0DB864E2" }
		};

		var response = await DeleteAsync(DeleteSavingEndpointTest.BuildUrl(userId), token, queryParameters);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndSavingIdThatExists_WhenDeleteSaving_ThenSavingIsDeletedFromDatabase()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var savingId = Guid.Parse("AF476108-6951-4246-BC4E-35EE0DB864E2");
		var queryParameters = new Dictionary<string, string>
		{
			{ "savingId", savingId.ToString() }
		};

		await DeleteAsync(DeleteSavingEndpointTest.BuildUrl(userId), token, queryParameters);
		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		var saving = await databaseContext.Savings.FindAsync(savingId);

		Assert.That(saving, Is.Null);
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
		return $"{SavingEndpointsMapper.Prefix}/{userId}";
	}
}