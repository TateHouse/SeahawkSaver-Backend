namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Password.PerformReset;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset;

[TestFixture]
public sealed class PasswordUserPerformResetCommandFactoryTest
{
	[Test]
	public void GivenPasswordUserPerformResetCommandProperties_WhenCreate_ThenReturnsPasswordUserPerformResetCommand()
	{
		var commandSettings = new CommandSettings(true, true);
		const string token = "TestingToken";
		const string password = "#Password4Testing";

		var result = PasswordUserPerformResetCommandFactory.Create(commandSettings, token, password);

		Assert.Multiple(() =>
		{
			Assert.That(result.CommandSettings, Is.EqualTo(commandSettings));
			Assert.That(result.Token, Is.EqualTo(token));
			Assert.That(result.Password, Is.EqualTo(password));
		});
	}
}