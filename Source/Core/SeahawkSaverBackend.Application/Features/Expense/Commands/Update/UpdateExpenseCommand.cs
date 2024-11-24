namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Update;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Update.DTOs;

/**
 * <summary>
 * A command for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> entity.
 * </summary>
 */
public sealed class UpdateExpenseCommand : Command<Unit>
{
	public required UpdateExpenseCommandExpenseRequest Expense { get; init; }
}