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

	public virtual ICollection<UserIncomeBridge>? UserIncomeBridges { get; set; }
}