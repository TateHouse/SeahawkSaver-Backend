namespace SeahawkSaverBackend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The Entity Framework Core entity configuration for the <see cref="Saving"/> entity.
 * </summary>
 */
public sealed class SavingConfiguration : IEntityTypeConfiguration<Saving>
{
	public void Configure(EntityTypeBuilder<Saving> builder)
	{
		builder.HasKey(saving => saving.SavingId);

		builder.Property(saving => saving.Amount)
			   .HasColumnName("Amount")
			   .IsRequired();

		builder.Property(saving => saving.DateTime)
			   .HasColumnName("DateTime")
			   .IsRequired();

		builder.HasOne(saving => saving.User)
			   .WithMany(user => user.Savings)
			   .HasForeignKey(saving => saving.UserId)
			   .IsRequired();
	}
}