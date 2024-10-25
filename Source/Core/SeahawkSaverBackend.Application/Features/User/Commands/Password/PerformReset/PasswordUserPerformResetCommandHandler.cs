namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;

/**
 * <summary>
 * The command handler for the <see cref="PasswordUserPerformResetCommand"/>.
 * </summary>
 */
public sealed class PasswordUserPerformResetCommandHandler : CommandHandler<PasswordUserPerformResetCommand, Unit>
{
	private readonly ITokenValidator tokenValidator;
	private readonly IPasswordHasher passwordHasher;

	/**
	 * <summary>
	 * Instantiates a new <see cref="PasswordUserPerformResetCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="tokenValidator">A token validator.</param>
	 * <param name="passwordHasher">A password hasher.</param>
	 */
	public PasswordUserPerformResetCommandHandler(ICommandTransaction transaction,
												  ITokenValidator tokenValidator,
												  IPasswordHasher passwordHasher)
		: base(transaction, null)
	{
		this.tokenValidator = tokenValidator;
		this.passwordHasher = passwordHasher;
	}

	protected override async Task<Unit> HandleAsync(PasswordUserPerformResetCommand request, CancellationToken cancellationToken)
	{
		var user = await tokenValidator.ValidateTokenAsync(request.Token, cancellationToken)!;
		var passwordHash = passwordHasher.Hash(request.Password);
		user.Password = passwordHash;

		await Transaction.UserRepository.UpdateAsync(user, cancellationToken);

		return Unit.Value;
	}
}