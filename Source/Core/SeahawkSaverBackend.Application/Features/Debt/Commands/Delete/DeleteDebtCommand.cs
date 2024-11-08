namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A command for deleting a <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entity.
 * </summary>
 */
public sealed class DeleteDebtCommand : Command<Unit>
{
	public required Guid DebtId { get; init; }
	public required Guid UserId { get; init; }
}