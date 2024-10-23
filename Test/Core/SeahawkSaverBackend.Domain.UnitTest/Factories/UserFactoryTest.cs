namespace SeahawkSaverBackend.Domain.UnitTest.Factories;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class UserFactoryTest
{
	[Test]
	public void GivenUserProperties_WhenCreate_ThenReturnsUser()
	{
		var userId = Guid.NewGuid();
		const string email = "test.user@example.com";
		const string password = "TestPassword";

		var user = UserFactory.Create(userId, email, password);

        Assert.Multiple(() =>
        {
            Assert.That(user.UserId, Is.EqualTo(userId));
            Assert.That(user.Email, Is.EqualTo(email));
            Assert.That(user.Password, Is.EqualTo(password));
        });
    }
}