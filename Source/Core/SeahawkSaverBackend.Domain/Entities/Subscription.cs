namespace SeahawkSaverBackend.Domain.Entities;
/**
 * <summary>
 * An entity that represents a subscription in the database.
 * </summary>
 */
public class Subscription 
{
    public required Guid SubscriptionId { get; set; }
	public required decimal Amount { get; set; }
	public required DateTime DateTime { get; set; }

	public Guid UserId { get; set; }
	public virtual User User { get; set; } = null!;

}