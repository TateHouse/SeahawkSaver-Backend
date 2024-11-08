namespace SeahawkSaverBackend.Authentication.UnitTest.Services;
using Ardalis.Specification;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Authentication.Services;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;
using System.Text;

[TestFixture]
public sealed class JwtTokenValidatorTest
{
	private TokenValidationParameters tokenValidationParameters;
	private Mock<IReadOnlyRepository<User>> mockUserRepository;
	private JwtTokenValidator jwtTokenValidator;
	private JwtTokenGenerator jwtTokenGenerator;

	[SetUp]
	public void SetUp()
	{
		var settings = new Dictionary<string, string?>
		{
			{ "JwtSettings:Issuer", "TestIssuer" },
			{ "JwtSettings:Audience", "TestAudience" }
		};

		var configurationBuilder = new ConfigurationBuilder();
		configurationBuilder.AddInMemoryCollection(settings);
		configurationBuilder.AddUserSecrets<JwtTokenGeneratorTest>();

		var configuration = configurationBuilder.Build();
		var authenticationSettings = new AuthenticationSettings(configuration);

		tokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = authenticationSettings.Issuer,
			ValidAudience = authenticationSettings.Audience,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.SecretKey))
		};

		mockUserRepository = new Mock<IReadOnlyRepository<User>>();
		jwtTokenValidator = new JwtTokenValidator(tokenValidationParameters, mockUserRepository.Object);
		jwtTokenGenerator = new JwtTokenGenerator(authenticationSettings);
	}

	[Test]
	public async Task GivenInvalidToken_WhenValidateTokenAsync_ThenThrowsUnauthorizedException()
	{
		Assert.ThrowsAsync<UnauthorizedException>(() => jwtTokenValidator.ValidateTokenAsync("InvalidToken", false, CancellationToken.None));
	}

	[Test]
	public async Task GivenValidToken_WhenValidateTokenAsyncAndUserDoesNotExist_ThenThrowsNotFoundException()
	{
		var user = UserFactory.Create(Guid.NewGuid(), "test.user@gmail.com", "#Password4Testing", "TestFirstName", "TestLastName", false);
		var token = jwtTokenGenerator.GenerateToken(user, DateTime.UtcNow.AddMinutes(10), false);

		mockUserRepository.Setup(mock => mock.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
						  .ReturnsAsync(() => null);

		Assert.ThrowsAsync<NotFoundException>(() => jwtTokenValidator.ValidateTokenAsync(token, false, CancellationToken.None));

		mockUserRepository.Verify(mock => mock.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	[TestCase(false)]
	[TestCase(true)]
	public async Task GivenValidToken_WhenValidateTokenAsyncAndUserExists_ThenReturnsUser(bool isForPasswordReset)
	{
		var user = UserFactory.Create(Guid.NewGuid(), "test.user@gmail.com", "#Password4Testing", "TestFirstName", "TestLastName", false);
		var token = string.Empty;

		if (isForPasswordReset)
		{
			token = jwtTokenGenerator.GenerateToken(user, DateTime.UtcNow.AddMinutes(10), true);
		}
		else
		{

			token = jwtTokenGenerator.GenerateToken(user, DateTime.UtcNow.AddMinutes(10), false);
		}

		mockUserRepository.Setup(mock => mock.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
						  .ReturnsAsync(() => user);

		var result = await jwtTokenValidator.ValidateTokenAsync(token, false, CancellationToken.None);

		Assert.Multiple(() => {
			Assert.That(result.UserId, Is.EqualTo(user.UserId));
			Assert.That(result.Email, Is.EqualTo(user.Email));
			Assert.That(result.Password, Is.EqualTo(user.Password));
			Assert.That(result.FirstName, Is.EqualTo(user.FirstName));
			Assert.That(result.LastName, Is.EqualTo(user.LastName));
		});

		mockUserRepository.Verify(mock => mock.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}