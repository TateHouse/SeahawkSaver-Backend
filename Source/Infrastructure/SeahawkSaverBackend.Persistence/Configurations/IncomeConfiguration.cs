namespace SeahawkSaverBackend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The Entity Framework Core entity configuration for the <see cref="Income"/> entity.
 * </summary>
 */
public sealed class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
	public void Configure(EntityTypeBuilder<Income> builder)
	{
		builder.HasKey(income => income.IncomeId);

		builder.Property(income => income.Amount)
			   .IsRequired();

		builder.Property(income => income.DateTime)
			   .IsRequired();

		builder.HasOne(income => income.User)
			   .WithMany(user => user.Incomes)
			   .HasForeignKey(income => income.UserId)
			   .IsRequired();
	}
}