namespace SeahawkSaverBackend.Application.UnitTest.Features.Debt.Commands.Validation;
using SeahawkSaverBackend.Application.Features.Debt.Commands;

public sealed record FakeDebtCommandRequest : DebtCommandRequest
{
	public Guid? UserId { get; set; }
	public Guid? DebtId { get; set; }
	public decimal? Amount { get; set; }
	public DateTime? DateTime { get; set; }
}