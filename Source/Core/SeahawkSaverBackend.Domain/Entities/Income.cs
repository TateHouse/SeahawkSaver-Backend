namespace SeahawkSaverBackend.Domain.Entities;
/**
 * <summary>
 * An entity that represents income in the database.
 * </summary>
 */
public class Income
{
	public required Guid IncomeId { get; set; }
	public required decimal Amount { get; set; }
	public required DateTime DateTime { get; set; }

	public Guid UserId { get; set; }
	public virtual User User { get; set; } = null!;
}