namespace SeahawkSaverBackend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeahawkSaverBackend.Domain.Entities;

public sealed class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
	public void Configure(EntityTypeBuilder<Income> builder)
	{
		builder.HasKey(income => income.IncomeId);

		builder.Property(income => income.Amount)
			   .IsRequired();

		builder.Property(income => income.DateTime)
			   .IsRequired();

		builder.HasMany(income => income.UserIncomeBridges)
			   .WithOne(bridge => bridge.Income)
			   .HasForeignKey(bridge => bridge.IncomeId);
	}
}