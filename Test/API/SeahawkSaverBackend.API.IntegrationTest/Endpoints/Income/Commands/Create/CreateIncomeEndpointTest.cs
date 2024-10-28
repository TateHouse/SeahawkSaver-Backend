namespace SeahawkSaverBackend.API.IntegrationTest.Endpoints.Income.Commands.Create;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.API.Endpoints.Income;
using SeahawkSaverBackend.API.Endpoints.Income.Commands.Create.DTOs;
using SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net;
using System.Net.Http.Json;

[TestFixture]
public sealed class CreateIncomeEndpointTest : EndpointTest
{
	[Test]
	public async Task GivenNoBearerToken_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateIncomeEndpointRequest
		{
			Income = new CreateIncomeEndpointIncomeRequest
			{
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-1)
			}
		};

		var response = await PostAsync(CreateIncomeEndpointTest.BuildUrl(userId), null, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenUserIdInRouteThatDoesNotMatchAuthenticatedUser_WhenAuthenticate_ThenReturnsUnauthorizedStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var request = new CreateIncomeEndpointRequest
		{
			Income = new CreateIncomeEndpointIncomeRequest
			{
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-1)
			}
		};

		var response = await PostAsync(CreateIncomeEndpointTest.BuildUrl(Guid.NewGuid()), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndInvalidIncomeRequest_WhenCreateIncome_ThenReturnsBadRequestStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateIncomeEndpointRequest
		{
			Income = new CreateIncomeEndpointIncomeRequest
			{
				Amount = -100,
				DateTime = DateTime.Now.AddDays(-3)
			}
		};

		var response = await PostAsync(CreateIncomeEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndValidIncomeRequest_WhenCreateIncome_ThenReturnsCreatedStatus()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateIncomeEndpointRequest
		{
			Income = new CreateIncomeEndpointIncomeRequest
			{
				Amount = 100,
				DateTime = DateTime.Now.AddDays(-1)
			}
		};

		var response = await PostAsync(CreateIncomeEndpointTest.BuildUrl(userId), token, request);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndValidIncomeRequest_WhenCreateIncome_ThenReturnsIncomeId()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateIncomeEndpointRequest
		{
			Income = new CreateIncomeEndpointIncomeRequest
			{
				Amount = 500,
				DateTime = DateTime.Now.AddDays(-7)
			}
		};

		var response = await PostAsync(CreateIncomeEndpointTest.BuildUrl(userId), token, request);
		var content = await response.Content.ReadFromJsonAsync<CreateIncomeEndpointResponse>();

		Assert.That(content, Is.Not.Null);
		Assert.That(content.IncomeId, Is.Not.Empty);
	}

	[Test]
	public async Task GivenAuthenticatedUserIdAndValidIncomeRequest_WhenCreateIncome_ThenIncomeIsAddedToDatabase()
	{
		await SeedDatabaseAsync();

		var token = await GetAuthenticationTokenAsync("peter.keller@gmail.com", "#Password4Peter");
		var userId = Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B");
		var request = new CreateIncomeEndpointRequest
		{
			Income = new CreateIncomeEndpointIncomeRequest
			{
				Amount = 250,
				DateTime = DateTime.Now.AddDays(-14)
			}
		};

		var response = await PostAsync(CreateIncomeEndpointTest.BuildUrl(userId), token, request);
		var content = await response.Content.ReadFromJsonAsync<CreateIncomeEndpointResponse>();

		Assert.That(content, Is.Not.Null);
		Assert.That(content.IncomeId, Is.Not.Empty);

		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		var income = await databaseContext.Incomes.FindAsync(content.IncomeId);

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