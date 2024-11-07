namespace SeahawkSaverBackend.Application.UnitTest.Features.Saving.Commands.Validation;
using SeahawkSaverBackend.Application.Features.Saving.Commands;

public sealed record FakeSavingCommandRequest : SavingCommandRequest
{
	public Guid? UserId { get; set; }
	public Guid? SavingId { get; set; }
	public decimal? Amount { get; set; }
	public DateTime? DateTime { get; set; }
}