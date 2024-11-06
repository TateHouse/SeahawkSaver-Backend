namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Saving.Queries.List;
using SeahawkSaverBackend.API.Endpoints.Saving;
using SeahawkSaverBackend.API.Endpoints.Saving.Queries.List.DTOs;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class ListSavingEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenNoBearerToken_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		var response = await GetAsync(ListSavingEndpointTest.BuildUrl(Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB")), null);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenUserIdInRouteThatDoesNotMatchAuthenticatedUser_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		await SeedDatabaseAsync();
		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var response = await GetAsync(ListSavingEndpointTest.BuildUrl(Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B")), token);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenAuthenticatedUserId_WhenListSaving_ThenReturnsOkStatus()
	{
		await SeedDatabaseAsync();
		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var response = await GetAsync(ListSavingEndpointTest.BuildUrl(Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB")), token);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
	}

	[Test]
	public async Task GivenAuthenticatedUserId_WhenListSaving_ThenReturnsSavingsForUser()
	{
		await SeedDatabaseAsync();
		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var response = await GetAsync(ListSavingEndpointTest.BuildUrl(Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB")), token);
		var content = await response.Content.ReadFromJsonAsync<ListSavingEndpointResponse>();

		Assert.That(content, Is.Not.Null);
		Assert.That(content.Savings, Has.Count.EqualTo(4));
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
		return $"{SavingEndpointsMapper.Prefix}/list/{userId}";
	}
}