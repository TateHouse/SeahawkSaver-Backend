namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer containing the data returned by the <see cref="CreateDebtCommand"/>.
 * </summary>
 */
public sealed record CreateDebtCommandResponse
{
	public required Guid DebtId { get; init; }
}