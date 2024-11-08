namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;

/**
 * <summary>
 * A command for creating a new <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entity.
 * </summary>
 */
public sealed class CreateDebtCommand : Command<CreateDebtCommandResponse>
{
	public required Guid UserId { get; init; }
	public required CreateDebtCommandDebtRequest Debt { get; init; }
}