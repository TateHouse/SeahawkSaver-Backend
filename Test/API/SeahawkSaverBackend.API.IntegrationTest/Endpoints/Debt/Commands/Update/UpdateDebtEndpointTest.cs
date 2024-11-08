namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Debt.Commands.Update;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.API.Endpoints.Debt;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Update.DTOs;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class UpdateDebtEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenAuthenticatedUserAndInvalidDebtRequest_WhenUpdateDebt_ThenReturnsBadRequestStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var request = new UpdateDebtEndpointRequest
		{
			Debt = new UpdateDebtEndpointDebtRequest
			{
				DebtId = Guid.Parse("CD382ABE-22AC-416D-A7AA-E3845EEA6964"),
				Amount = -100,
				DateTime = DateTime.Now.AddDays(-4)
			}
		};

		var response = await PutAsync(UpdateDebtEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}

	[Test]
	public async Task GivenAuthenticatedUserAndValidDebtRequest_WhenUpdateDebt_ThenReturnsNoContentStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var request = new UpdateDebtEndpointRequest
		{
			Debt = new UpdateDebtEndpointDebtRequest
			{
				DebtId = Guid.Parse("CD382ABE-22AC-416D-A7AA-E3845EEA6964"),
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-4)
			}
		};

		var response = await PutAsync(UpdateDebtEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
	}

	[Test]
	public async Task GivenAuthenticatedUserAndValidDebtRequest_WhenUpdateDebt_ThenDebtIsUpdatedInDatabase()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("vicky.decker@yahoo.com", "#Password4Vicky");
		var userId = Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB");
		var request = new UpdateDebtEndpointRequest
		{
			Debt = new UpdateDebtEndpointDebtRequest
			{
				DebtId = Guid.Parse("CD382ABE-22AC-416D-A7AA-E3845EEA6964"),
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-4)
			}
		};

		await PutAsync(UpdateDebtEndpointTest.BuildUrl(userId), token, request);
		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		var debt = await databaseContext.Debts.FindAsync(request.Debt.DebtId);

		Assert.That(debt, Is.Not.Null);
		Assert.Multiple(() =>
		{
			Assert.That(debt.Amount, Is.EqualTo(request.Debt.Amount));
			Assert.That(debt.DateTime, Is.EqualTo(request.Debt.DateTime));
			Assert.That(debt.UserId, Is.EqualTo(userId));
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
		return $"{DebtEndpointsMapper.Prefix}/{userId}";
	}
}