namespace SeahawkSaverBackend.Application.UnitTest.Abstractions.Commands;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

[TestFixture]
public sealed class CommandSettingsTest
{
	[Test]
	public void GivenInvalidSaveAndCommitCombination_WhenInstantiate_ThenThrowsArgumentException()
	{
		Assert.Throws<ArgumentException>(() => new CommandSettings(false, true));
	}

	[Test]
	[TestCase(true, true)]
	[TestCase(true, false)]
	[TestCase(false, false)]
	public void GivenValidSaveAndCommitCombinations_WhenInstantiate_ThenReturnsCommandSettingsInstance(bool save, bool commit)
	{
		var commandSettings = new CommandSettings(save, commit);

		Assert.That(commandSettings, Is.Not.Null);
	}
}