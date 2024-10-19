namespace SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using FluentValidation;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using ValidationException=SeahawkSaverBackend.Application.Exceptions.ValidationException;

/**
 * <summary>
 * The base class for all command handlers.
 * </summary>
 * <remarks>
 * Each <see cref="CommandHandler{TCommand,TCommandResponse}"/> must have an associated <see cref="Command{TCommandResponse}"/>.
 * </remarks>
 * <typeparam name="TCommand">The type of the command.</typeparam>
 * <typeparam name="TCommandResponse">The type of the response that the <see cref="Command{TCommandResponse}"/> returns.</typeparam>
 */
public abstract class CommandHandler<TCommand, TCommandResponse> : IRequestHandler<TCommand, TCommandResponse>
	where TCommand : Command<TCommandResponse>
{
	protected readonly ICommandTransaction Transaction;
	private readonly IValidator<TCommand>? validator;

	/**
	 * <summary>
	 * Instantiates a new <see cref="CommandHandler{TCommand,TCommandResponse}"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 */
	protected CommandHandler(ICommandTransaction transaction, IValidator<TCommand>? validator)
	{
		Transaction = transaction;
		this.validator = validator;
	}

	/**
	 * <summary>
	 * Asynchronously validates the command fi a validator was provided.
	 * </summary>
	 * <param name="request">The command to validate.</param>
	 * <param name="cancellationToken">A token to cancel the operation.</param>
	 * <returns>A task that represents the asynchronous operation.</returns>
	 * <exception cref="ValidationException">Thrown if the validation fails.</exception>
	 */
	private async Task ValidateAsync(TCommand request, CancellationToken cancellationToken)
	{
		if (validator == null)
		{
			return;
		}

		var validationResult = await validator.ValidateAsync(request, cancellationToken);

		if (validationResult.Errors.Count > 0)
		{
			throw new ValidationException(validationResult);
		}
	}

	/**
	 * <summary>
	 * Asynchronously handles the command.
	 * </summary>
	 * <remarks>
	 * This is where each command provides its implementation.
	 * </remarks>
	 * <param name="request">The command.</param>
	 * <param name="cancellationToken">A token to cancel the operation.</param>
	 * <typeparam name="TCommandResponse">The type of the response that the <see cref="Command{TCommandResponse}"/> returns.</typeparam>
	 * <returns>A task that represents the asynchronous operation, and it contains the response of type <typeparamref name="TCommandResponse"/>.</returns>
	 */
	protected abstract Task<TCommandResponse> HandleAsync(TCommand request, CancellationToken cancellationToken);

	public async Task<TCommandResponse> Handle(TCommand request, CancellationToken cancellationToken)
	{
		try
		{
			await ValidateAsync(request, cancellationToken);

			if (Transaction.HasTransactionStarted == false)
			{
				await Transaction.BeginTransactionAsync();
			}

			var response = await HandleAsync(request, cancellationToken);

			if (request.CommandSettings.Save == false)
			{
				return response;
			}

			await Transaction.SaveChangesAsync();

			if (request.CommandSettings.Commit == true)
			{
				await Transaction.CommitTransactionAsync();
			}

			return response;
		}
		catch (Exception)
		{
			await Transaction.RollbackTransactionAsync();

			throw;
		}
	}
}