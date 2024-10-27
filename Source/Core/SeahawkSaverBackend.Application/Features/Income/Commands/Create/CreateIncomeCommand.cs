namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;

/**
 * <summary>
 * A command for creating a new <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> entity.
 * </summary>
 */
public sealed class CreateIncomeCommand : Command<CreateIncomeCommandResponse>
{
	public required Guid UserId { get; init; }
	public required CreateIncomeCommandIncomeRequest Income { get; init; }
}