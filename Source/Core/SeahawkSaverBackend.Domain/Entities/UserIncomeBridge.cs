namespace SeahawkSaverBackend.Domain.Entities;
public class UserIncomeBridge
{
	public required Guid UserId { get; set; }
	public virtual User User { get; set; } = null!;

	public required Guid IncomeId { get; set; }
	public virtual Income Income { get; set; } = null!;
}