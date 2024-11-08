namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> data provided in the
 * request for the <see cref="UpdateDebtCommand"/>.
 * </summary>
 */
public sealed record UpdateDebtCommandDebtRequest : DebtCommandRequest
{
	public required Guid UserId { get; init; }
	public required Guid DebtId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}