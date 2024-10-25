namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.RequestReset;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Abstractions.Communication;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="PasswordUserRequestResetCommand"/>.
 * </summary>
 */
public sealed class PasswordUserRequestResetCommandHandler : CommandHandler<PasswordUserRequestResetCommand, Unit>
{
	private readonly ITokenGenerator tokenGenerator;
	private readonly IPasswordResetEmailService passwordResetEmailService;

	/**
	 * <summary>
	 * Instantiates a new <see cref="PasswordUserRequestResetCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="tokenGenerator">A token generator.</param>
	 * <param name="passwordResetEmailService">A password reset email service.</param>
	 */
	public PasswordUserRequestResetCommandHandler(ICommandTransaction transaction,
												  ITokenGenerator tokenGenerator,
												  IPasswordResetEmailService passwordResetEmailService)
		: base(transaction, null)
	{
		this.tokenGenerator = tokenGenerator;
		this.passwordResetEmailService = passwordResetEmailService;
	}

	protected override async Task<Unit> HandleAsync(PasswordUserRequestResetCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetUserByEmailSpecification(request.Email);
		var user = await Transaction.UserRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException(nameof(User), request.Email);
		}

		var tokenExpirationDateTime = DateTime.UtcNow.AddMinutes(15);
		var token = tokenGenerator.GenerateToken(user, tokenExpirationDateTime);
		await passwordResetEmailService.SendResetPasswordEmailAsync(user.Email, token, cancellationToken);

		return Unit.Value;
	}
}