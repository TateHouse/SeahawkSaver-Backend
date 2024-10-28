namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Income.Commands.Delete;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.API.Endpoints.Income;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class DeleteIncomeEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenNoBearerToken_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var queryParameters = new Dictionary<string, string>
		{
			{ "incomeId", "CC15E589-CE4D-419C-90F5-73B4181892FF" }
		};

		var response = await DeleteAsync(DeleteIncomeEndpointTest.BuildUrl(userId), null, queryParameters);

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
			{ "incomeId", "CC15E589-CE4D-419C-90F5-73B4181892FF" }
		};

		var response = await DeleteAsync(DeleteIncomeEndpointTest.BuildUrl(userId), token, queryParameters);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndIncomeIdThatDoesNotExist_WhenDeleteIncome_ThenReturnsNotFoundStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var queryParameters = new Dictionary<string, string>
		{
			{ "incomeId", "4B1B0C98-761C-4E67-AB7B-2FA67EF3A33E" }
		};

		var response = await DeleteAsync(DeleteIncomeEndpointTest.BuildUrl(userId), token, queryParameters);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndIncomeIdThatExists_WhenDeleteIncome_ThenReturnsNoContentStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var queryParameters = new Dictionary<string, string>
		{
			{ "incomeId", "CC15E589-CE4D-419C-90F5-73B4181892FF" }
		};

		var response = await DeleteAsync(DeleteIncomeEndpointTest.BuildUrl(userId), token, queryParameters);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndIncomeIdThatExists_WhenDeleteIncome_ThenIncomeIsDeletedFromDatabase()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var incomeId = Guid.Parse("CC15E589-CE4D-419C-90F5-73B4181892FF");
		var queryParameters = new Dictionary<string, string>
		{
			{ "incomeId", incomeId.ToString() }
		};

		await DeleteAsync(DeleteIncomeEndpointTest.BuildUrl(userId), token, queryParameters);
		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		var income = await databaseContext.Incomes.FindAsync(incomeId);

		Assert.That(income, Is.Null);
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
		return $"{IncomeEndpointsMapper.Prefix}/{userId}";
	}
}