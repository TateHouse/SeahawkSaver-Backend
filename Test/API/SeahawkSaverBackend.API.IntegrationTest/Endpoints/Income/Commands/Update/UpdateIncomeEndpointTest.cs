namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Income.Commands.Update;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.API.Endpoints.Income;
using SeahawkSaverBackend.API.Endpoints.Income.Commands.Update.DTOs;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class UpdateIncomeEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenAuthenticatedUserAndInvalidIncomeRequest_WhenUpdateIncome_ThenReturnsBadRequestStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var request = new UpdateIncomeEndpointRequest
		{
			Income = new UpdateIncomeEndpointIncomeRequest
			{
				IncomeId = Guid.Parse("CD382ABE-22AC-416D-A7AA-E3845EEA6964"),
				Amount = -100,
				DateTime = DateTime.Now.AddDays(-4)
			}
		};

		var response = await PutAsync(UpdateIncomeEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}

	[Test]
	public async Task GivenAuthenticatedUserAndValidIncomeRequest_WhenUpdateIncome_ThenReturnsNoContentStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var request = new UpdateIncomeEndpointRequest
		{
			Income = new UpdateIncomeEndpointIncomeRequest
			{
				IncomeId = Guid.Parse("CD382ABE-22AC-416D-A7AA-E3845EEA6964"),
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-4)
			}
		};

		var response = await PutAsync(UpdateIncomeEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
	}

	[Test]
	public async Task GivenAuthenticatedUserAndValidIncomeRequest_WhenUpdateIncome_ThenIncomeIsUpdatedInDatabase()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var request = new UpdateIncomeEndpointRequest
		{
			Income = new UpdateIncomeEndpointIncomeRequest
			{
				IncomeId = Guid.Parse("CD382ABE-22AC-416D-A7AA-E3845EEA6964"),
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-4)
			}
		};

		await PutAsync(UpdateIncomeEndpointTest.BuildUrl(userId), token, request);
		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		var income = await databaseContext.Incomes.FindAsync(request.Income.IncomeId);

		Assert.That(income, Is.Not.Null);
		Assert.Multiple(() =>
		{
			Assert.That(income.Amount, Is.EqualTo(request.Income.Amount));
			Assert.That(income.DateTime, Is.EqualTo(request.Income.DateTime));
			Assert.That(income.UserId, Is.EqualTo(userId));
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
		return $"{IncomeEndpointsMapper.Prefix}/{userId}";
	}
}