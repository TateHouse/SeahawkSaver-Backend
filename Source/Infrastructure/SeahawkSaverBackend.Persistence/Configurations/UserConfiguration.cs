namespace SeahawkSaverBackend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The Entity Framework Core entity configuration for the <see cref="User"/> entity.
 * </summary>
 */
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(user => user.UserId);

		builder.Property(user => user.Email)
			   .HasColumnName("Email")
			   .IsRequired();

		builder.Property(user => user.Password)
			   .HasColumnName("Password")
			   .IsRequired();

		builder.Property(user => user.FirstName)
			   .HasColumnName("FirstName")
			   .IsRequired();

		builder.Property(user => user.LastName)
			   .HasColumnName("LastName")
			   .IsRequired();

		builder.HasMany(user => user.UserIncomeBridges)
			   .WithOne(bridge => bridge.User)
			   .HasForeignKey(bridge => bridge.UserId);
	}
}