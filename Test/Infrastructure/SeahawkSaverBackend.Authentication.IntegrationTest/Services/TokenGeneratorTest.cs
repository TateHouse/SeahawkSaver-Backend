namespace SeahawkSaverBackend.Authentication.UnitTest.Services;
using Microsoft.Extensions.Configuration;
using SeahawkSaverBackend.Authentication.Services;
using SeahawkSaverBackend.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

[TestFixture]
public sealed class TokenGeneratorTest
{
	private User user;
	private TokenGenerator tokenGenerator;
	private AuthenticationSettings authenticationSettings;

	[SetUp]
	public void SetUp()
	{
		user = new User
		{
			UserId = Guid.NewGuid(),
			Email = "test.user@example.com",
			Password = "$2a$04$cuKSyWCrNH35niKtV5miyO.CiQtZXZ2BtV1D/Rhb.dtU1.WufrAXS",
		};

		var settings = new Dictionary<string, string?>
		{
			{ "JwtSettings:Issuer", "TestIssuer" },
			{ "JwtSettings:Audience", "TestAudience" }
		};

		var configurationBuilder = new ConfigurationBuilder();
		configurationBuilder.AddInMemoryCollection(settings);
		configurationBuilder.AddUserSecrets<TokenGeneratorTest>();

		var configuration = configurationBuilder.Build();
		authenticationSettings = new AuthenticationSettings(configuration);
		tokenGenerator = new TokenGenerator(authenticationSettings);
	}

	[Test]
	public void GivenUser_WhenGenerateToken_ThenReturnsToken()
	{
		var token = tokenGenerator.GenerateToken(user);

		Assert.That(token, Is.Not.Empty);
	}

	[Test]
	public void GivenUser_WhenGenerateToken_ThenTokenPropertiesAreSet()
	{
		var token = tokenGenerator.GenerateToken(user);
		var tokenHandler = new JwtSecurityTokenHandler();
		var securityToken = tokenHandler.ReadJwtToken(token);

		Assert.Multiple(() =>
		{
			Assert.That(securityToken.Subject, Is.EqualTo(user.UserId.ToString()));
			Assert.That(securityToken.Claims.First(claim => claim.Type == "email").Value, Is.EqualTo(user.Email));
			Assert.That(securityToken.Issuer, Is.EqualTo(authenticationSettings.Issuer));
			Assert.That(securityToken.Audiences.First(), Is.EqualTo(authenticationSettings.Audience));
		});
	}

	[Test]
	public void GivenUser_WhenGenerateToken_ThenExpiresAfterOneHour()
	{
		var token = tokenGenerator.GenerateToken(user);
		var tokenHandler = new JwtSecurityTokenHandler();
		var securityToken = tokenHandler.ReadJwtToken(token);

		Assert.That(securityToken.ValidTo, Is.GreaterThan(DateTime.UtcNow));
		Assert.That(securityToken.ValidTo, Is.LessThan(DateTime.UtcNow.AddHours(1)));
	}
}