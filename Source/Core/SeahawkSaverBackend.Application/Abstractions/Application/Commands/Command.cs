namespace SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using MediatR;

/**
 * <summary>
 * The base class for commands.
 * </summary>
 * <remarks>
 * Each command must also have an associated <see cref="CommandHandler{TCommand,TCommandResponse}"/>.
 * </remarks>
 * <typeparam name="TCommandResponse">The type of the response that the <see cref="Command{TCommandResponse}"/> returns.</typeparam>
 */
public abstract class Command<TCommandResponse> : IRequest<TCommandResponse>
{
	public required CommandSettings CommandSettings { get; init; }
}