namespace SeahawkSaverBackend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The Entity Framework Core entity configuration for the <see cref="Expense"/> entity.
 * </summary>
 */
public sealed class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
	public void Configure(EntityTypeBuilder<Expense> builder)
	{
		builder.HasKey(expense => expense.ExpenseId);

		builder.Property(expense => expense.Amount)
			   .HasColumnName("Expense")
			   .IsRequired();

		builder.Property(expense => expense.DateTime)
			   .HasColumnName("DateTime")
			   .IsRequired();

		builder.HasOne(expense => expense.User)
			   .WithMany(user => user.Expenses)
			   .HasForeignKey(expense => expense.UserId)
			   .IsRequired();
	}
}