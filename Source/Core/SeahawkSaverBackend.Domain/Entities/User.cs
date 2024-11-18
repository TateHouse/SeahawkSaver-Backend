namespace SeahawkSaverBackend.Domain.Entities;
/**
 * <summary>
 * An entity that represents a user in the database.
 * </summary>
 */
public class User
{
	public required Guid UserId { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required bool IsAdmin { get; set; }
	public required bool IsActive { get; set; }

	public virtual ICollection<Income> Incomes { get; } = null!;
	public virtual ICollection<Saving> Savings { get; } = null!;
	public virtual ICollection<Subscription> Subscriptions { get; } = null!;
}