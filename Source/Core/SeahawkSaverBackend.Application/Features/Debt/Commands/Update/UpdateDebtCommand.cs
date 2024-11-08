namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Update;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Update.DTOs;

/**
 * <summary>
 * A command for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entity.
 * </summary>
 */
public sealed class UpdateDebtCommand : Command<Unit>
{
	public required UpdateDebtCommandDebtRequest Debt { get; init; }
}