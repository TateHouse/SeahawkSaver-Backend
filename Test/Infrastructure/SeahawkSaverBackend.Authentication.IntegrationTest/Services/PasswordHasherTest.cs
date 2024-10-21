namespace SeahawkSaverBackend.Authentication.UnitTest.Services;
using SeahawkSaverBackend.Authentication.Services;

[TestFixture]
public sealed class PasswordHasherTest
{
	private PasswordHasher passwordHasher;

	[SetUp]
	public void SetUp()
	{
		passwordHasher = new PasswordHasher();
	}

	[Test]
	public void GivenPassword_WhenHash_ThenReturnsPasswordHash()
	{
		const string password = "#Password4Testing";
		var hash = passwordHasher.Hash(password);

		Assert.That(hash, Is.Not.EqualTo(password));
	}

	[Test]
	[TestCase("#Password4Testing", true)]
	[TestCase("!Password4Testing", false)]
	public void GivenPassword_WhenVerify_ThenReturnsExpectedBool(string password, bool expectedResult)
	{
		var hash = passwordHasher.Hash("#Password4Testing");
		var isValid = passwordHasher.Verify(password, hash);

		Assert.That(isValid, Is.EqualTo(expectedResult));
	}

	[Test]
	public void GivenPassword_WhenHash_ThenReturnsDifferenceHashesForSamePassword()
	{
		const string password = "#Password4Testing";
		var firstHash = passwordHasher.Hash(password);
		var secondHash = passwordHasher.Hash(password);

		Assert.That(firstHash, Is.Not.EqualTo(secondHash));
	}
}