namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Commands.Validation;
using SeahawkSaverBackend.Application.Features.Income.Commands;

public sealed record FakeIncomeCommandRequest : IncomeCommandRequest
{
	public Guid? UserId { get; set; }
	public Guid? IncomeId { get; set; }
	public decimal? Amount { get; set; }
	public DateTime? DateTime { get; set; }
}