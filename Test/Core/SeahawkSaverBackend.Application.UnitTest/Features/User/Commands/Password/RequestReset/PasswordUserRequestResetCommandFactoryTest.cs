namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Password.RequestReset;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.RequestReset;

[TestFixture]
public sealed class PasswordUserRequestResetCommandFactoryTest
{
	[Test]
	public void GivenPasswordUserRequestResetCommandProperties_WhenCreate_ThenReturnsPasswordUserRequestResetCommand()
	{
		var commandSettings = new CommandSettings(true, true);
		const string email = "test.user@example.com";

		var result = PasswordUserRequestResetCommandFactory.Create(commandSettings, email);

		Assert.Multiple(() =>
		{
			Assert.That(result.CommandSettings, Is.EqualTo(commandSettings));
			Assert.That(result.Email, Is.EqualTo(email));
		});
	}
}