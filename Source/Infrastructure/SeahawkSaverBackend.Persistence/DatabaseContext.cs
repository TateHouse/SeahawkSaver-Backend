namespace SeahawkSaverBackend.Persistence;
using Microsoft.EntityFrameworkCore;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The application's Entity Framework Core <see cref="DbContext"/>.
 * </summary>
 */
public sealed class DatabaseContext : DbContext
{
	/**
	 * <summary>
	 * The <see cref="User"/> entities in the database.
	 * </summary>
	 */
	public DbSet<User> Users { get; set; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="DatabaseContext"/> instance.
	 * </summary>
	 * <param name="databaseContextOptions">The options to be used by the <see cref="DatabaseContext"/>.</param>
	 */
	public DatabaseContext(DbContextOptions databaseContextOptions)
		: base(databaseContextOptions)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
	}
}