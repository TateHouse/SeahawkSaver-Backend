namespace SeahawkSaverBackend.Application.UnitTest.Abstractions.Commands;
using FluentValidation;

public sealed class FakeCommandValidator : AbstractValidator<FakeCommand>
{
	public FakeCommandValidator()
	{
		RuleFor(command => command.Name)
			.NotEmpty();
	}
}