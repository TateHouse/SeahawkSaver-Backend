namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Login;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Login;

[TestFixture]
public sealed class LoginUserCommandFactoryTest
{
	[Test]
	public void GivenLoginUserCommandProperties_WhenCreate_ThenReturnsLoginUserCommand()
	{
		var commandSettings = new CommandSettings(true, true);
		const string email = "test.user@example.com";
		const string password = "TestPassword";

		var loginUserCommand = LoginUserCommandFactory.Create(commandSettings, email, password);

		Assert.Multiple(() =>
		{
			Assert.That(loginUserCommand.CommandSettings, Is.EqualTo(commandSettings));
			Assert.That(loginUserCommand.Email, Is.EqualTo(email));
			Assert.That(loginUserCommand.Password, Is.EqualTo(password));
		});
	}
}