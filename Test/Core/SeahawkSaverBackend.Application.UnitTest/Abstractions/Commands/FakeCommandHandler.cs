namespace SeahawkSaverBackend.Application.UnitTest.Abstractions.Commands;
using FluentValidation;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;

public sealed class FakeCommandHandler : CommandHandler<FakeCommand, bool>
{
	public FakeCommandHandler(ICommandTransaction transaction, IValidator<FakeCommand>? validator)
		: base(transaction, validator)
	{

	}

	protected override async Task<bool> HandleAsync(FakeCommand request, CancellationToken cancellationToken)
	{
		return await Task.Run(() => true, cancellationToken);
	}
}