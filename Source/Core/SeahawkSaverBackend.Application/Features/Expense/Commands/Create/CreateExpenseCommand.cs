namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Create.DTOs;

/**
 * <summary>
 * A command for creating a new <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> entity.
 * </summary>
 */
public class CreateExpenseCommand : Command<CreateExpenseCommandResponse>
{
	public required Guid UserId { get; init; }
	public required CreateExpenseCommandExpenseRequest Expense { get; init; }
}