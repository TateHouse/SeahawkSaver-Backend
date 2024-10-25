namespace SeahawkSaverBackend.Authentication.UnitTest.Services;
using Microsoft.AspNetCore.Http;
using SeahawkSaverBackend.Authentication.Services;

[TestFixture]
public sealed class JwtTokenExtractorTest
{
	private DefaultHttpContext httpContext;
	private JwtTokenExtractor jwtTokenExtractor;

	[SetUp]
	public void SetUp()
	{
		httpContext = new DefaultHttpContext();
		jwtTokenExtractor = new JwtTokenExtractor();
	}

	[Test]
	public void GivenNoAuthorizationHeader_WhenExtractToken_ThenThrowsInvalidOperationException()
	{
		Assert.Throws<InvalidOperationException>(() => jwtTokenExtractor.ExtractToken(httpContext));
	}

	[Test]
	public void GivenInvalidAuthorizationHeader_WhenExtractToken_ThenThrowsInvalidOperationException()
	{
		httpContext.Request.Headers.Authorization = "InvalidHeaderFormat";

		Assert.Throws<InvalidOperationException>(() => jwtTokenExtractor.ExtractToken(httpContext));
	}

	[Test]
	public void GivenValidAuthorizationHeader_WhenExtractToken_ThenReturnsToken()
	{
		const string token = "TestToken";
		httpContext.Request.Headers.Authorization = $"Bearer {token}";
		var result = jwtTokenExtractor.ExtractToken(httpContext);

		Assert.That(result, Is.EqualTo(token));
	}
}