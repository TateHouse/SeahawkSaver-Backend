namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Debt.Commands.Create;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.API.Endpoints.Debt;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create.DTOs;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class CreateDebtEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenNoBearerToken_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateDebtEndpointRequest
		{
			Debt = new CreateDebtEndpointDebtRequest
			{
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-1)
			}
		};

		var response = await PostAsync(CreateDebtEndpointTest.BuildUrl(userId), null, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenUserIdInRouteThatDoesNotMatchAuthenticatedUser_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var request = new CreateDebtEndpointRequest
		{
			Debt = new CreateDebtEndpointDebtRequest
			{
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-1)
			}
		};

		var response = await PostAsync(CreateDebtEndpointTest.BuildUrl(Guid.NewGuid()), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndInvalidDebtRequest_WhenCreateDebt_ThenReturnsBadRequestStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateDebtEndpointRequest
		{
			Debt = new CreateDebtEndpointDebtRequest
			{
				Amount = -100,
				DateTime = DateTime.Now.AddDays(-3)
			}
		};

		var response = await PostAsync(CreateDebtEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndValidDebtRequest_WhenCreateDebt_ThenReturnsCreatedStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateDebtEndpointRequest
		{
			Debt = new CreateDebtEndpointDebtRequest
			{
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-1)
			}
		};

		var response = await PostAsync(CreateDebtEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndValidDebtRequest_WhenCreateDebt_ThenReturnsDebtId()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateDebtEndpointRequest
		{
			Debt = new CreateDebtEndpointDebtRequest
			{
				Amount = 500,
				DateTime = DateTime.Now.AddDays(-7)
			}
		};

		var response = await PostAsync(CreateDebtEndpointTest.BuildUrl(userId), token, request);
		var content = await response.Content.ReadFromJsonAsync<CreateDebtEndpointResponse>();

		Assert.That(content, Is.Not.Null);
		Assert.That(content.DebtId, Is.Not.Empty);
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndValidDebtRequest_WhenCreateDebt_ThenDebtIsAddedToDatabase()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateDebtEndpointRequest
		{
			Debt = new CreateDebtEndpointDebtRequest
			{
				Amount = 250,
				DateTime = DateTime.Now.AddDays(-14)
			}
		};

		var response = await PostAsync(CreateDebtEndpointTest.BuildUrl(userId), token, request);
		var content = await response.Content.ReadFromJsonAsync<CreateDebtEndpointResponse>();

		Assert.That(content, Is.Not.Null);
		Assert.That(content.DebtId, Is.Not.Empty);

		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		var debt = await databaseContext.Debts.FindAsync(content.DebtId);

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