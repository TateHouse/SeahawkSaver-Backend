namespace SeahawkSaverBackend.Application.UnitTest.Abstractions.Commands;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

public sealed class FakeCommand : Command<bool>
{
	public required string Name { get; init; }
}