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
}