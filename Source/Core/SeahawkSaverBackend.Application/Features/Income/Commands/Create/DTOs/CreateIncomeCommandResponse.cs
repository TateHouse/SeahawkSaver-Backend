namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer containing the data returned by the <see cref="CreateIncomeCommand"/>.
 * </summary>
 */
public sealed record CreateIncomeCommandResponse
{
	public required Guid IncomeId { get; init; }
}