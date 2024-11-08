namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> data provided in the
 * request for the <see cref="CreateDebtCommand"/>.
 * </summary>
 */
public sealed record CreateDebtCommandDebtRequest : DebtCommandRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}