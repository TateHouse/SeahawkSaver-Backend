namespace SeahawkSaverBackend.Authentication.UnitTest.Services;
using Microsoft.Extensions.Configuration;
using SeahawkSaverBackend.Authentication.Services;
using SeahawkSaverBackend.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

[TestFixture]
public sealed class JwtTokenGeneratorTest
{
	private User user;
	private DateTime tokenExpirationDateTime;
	private JwtTokenGenerator jwtTokenGenerator;
	private AuthenticationSettings authenticationSettings;

	[SetUp]
	public void SetUp()
	{
		user = new User
		{
			UserId = Guid.NewGuid(),
			Email = "test.user@example.com",
			Password = "$2a$04$cuKSyWCrNH35niKtV5miyO.CiQtZXZ2BtV1D/Rhb.dtU1.WufrAXS",
			FirstName = "TestFirstName",
			LastName = "TestLastName"
		};

		tokenExpirationDateTime = DateTime.UtcNow.AddMinutes(5);
		var settings = new Dictionary<string, string?>
		{
			{ "JwtSettings:Issuer", "TestIssuer" },
			{ "JwtSettings:Audience", "TestAudience" }
		};

		var configurationBuilder = new ConfigurationBuilder();
		configurationBuilder.AddInMemoryCollection(settings);
		configurationBuilder.AddUserSecrets<JwtTokenGeneratorTest>();

		var configuration = configurationBuilder.Build();
		authenticationSettings = new AuthenticationSettings(configuration);
		jwtTokenGenerator = new JwtTokenGenerator(authenticationSettings);
	}

	[Test]
	public void GivenUser_WhenGenerateToken_ThenReturnsToken()
	{
		var token = jwtTokenGenerator.GenerateToken(user, tokenExpirationDateTime, false);

		Assert.That(token, Is.Not.Empty);
	}

	[Test]
	[TestCase(false)]
	[TestCase(true)]
	public void GivenUser_WhenGenerateToken_ThenTokenPropertiesAreSet(bool isForPasswordReset)
	{
		var token = jwtTokenGenerator.GenerateToken(user, tokenExpirationDateTime, isForPasswordReset);
		var tokenHandler = new JwtSecurityTokenHandler();
		var securityToken = tokenHandler.ReadJwtToken(token);

		Assert.Multiple(() =>
		{
			Assert.That(securityToken.Subject, Is.EqualTo(user.UserId.ToString()));
			Assert.That(securityToken.Claims.First(claim => claim.Type == "email").Value, Is.EqualTo(user.Email));
			Assert.That(securityToken.Issuer, Is.EqualTo(authenticationSettings.Issuer));
			Assert.That(securityToken.Audiences.First(), Is.EqualTo(authenticationSettings.Audience));
		});

		if (isForPasswordReset)
		{
			Assert.That(securityToken.Claims.First(claim => claim.Type == "purpose").Value, Is.EqualTo("password-reset"));
		}
	}

	[Test]
	public void GivenUser_WhenGenerateToken_ThenExpiresAfterOneHour()
	{
		var token = jwtTokenGenerator.GenerateToken(user, tokenExpirationDateTime, false);
		var tokenHandler = new JwtSecurityTokenHandler();
		var securityToken = tokenHandler.ReadJwtToken(token);

		Assert.That(securityToken.ValidTo, Is.GreaterThan(DateTime.UtcNow));
		Assert.That(securityToken.ValidTo, Is.LessThan(DateTime.UtcNow.AddHours(1)));
	}
}