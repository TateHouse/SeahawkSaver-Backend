namespace SeahawkSaverBackend.Application.Features.Income.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A command for deleting a <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> entity.
 * </summary>
 */
public sealed class DeleteIncomeCommand : Command<Unit>
{
	public required Guid IncomeId { get; init; }
	public required Guid UserId { get; init; }
}