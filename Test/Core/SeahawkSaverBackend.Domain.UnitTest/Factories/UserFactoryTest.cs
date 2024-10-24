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
		const string firstName = "TestFirstName";
		const string lastName = "TestLastName";

		var user = UserFactory.Create(userId, email, password, firstName, lastName);

		Assert.Multiple(() =>
		{
			Assert.That(user.UserId, Is.EqualTo(userId));
			Assert.That(user.Email, Is.EqualTo(email));
			Assert.That(user.Password, Is.EqualTo(password));
			Assert.That(user.FirstName, Is.EqualTo(firstName));
			Assert.That(user.LastName, Is.EqualTo(lastName));
		});
	}
}