namespace SeahawkSaverBackend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The Entity Framework Core entity configuration for the <see cref="Subscription"/> entity.
 * </summary>
 */
public sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
	public void Configure(EntityTypeBuilder<Subscription> builder)
	{
		builder.HasKey(subscription => subscription.SubscriptionId);

		builder.Property(subscription => subscription.Amount)
			   .HasColumnName("Amount")
			   .IsRequired();

		builder.Property(subscription => subscription.DateTime)
			   .HasColumnName("DateTime")
			   .IsRequired();

		builder.HasOne(subscription => subscription.User)
			   .WithMany(user => user.Subscriptions)
			   .HasForeignKey(subscription => subscription.UserId)
			   .IsRequired();
	}
}