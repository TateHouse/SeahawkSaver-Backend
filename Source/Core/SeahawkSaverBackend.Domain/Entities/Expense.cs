namespace SeahawkSaverBackend.Domain.Entities;
/**
 * <summary>
 * An entity that represents general expenses in the database.
 * </summary>
 */
public class Expense
{
	public required Guid ExpenseId { get; set; }
	public required decimal Amount { get; set; }
	public required DateTime DateTime { get; set; }

	public Guid UserId { get; set; }
	public virtual User User { get; set; } = null!;
}