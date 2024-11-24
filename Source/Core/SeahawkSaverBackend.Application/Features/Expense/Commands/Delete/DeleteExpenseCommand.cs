namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A command for deleting a <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> entity.
 * </summary>
 */
public sealed class DeleteExpenseCommand : Command<Unit>
{
	public required Guid ExpenseId { get; init; }
	public required Guid UserId { get; init; }
}