namespace SeahawkSaverBackend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeahawkSaverBackend.Domain.Entities;

public sealed class UserIncomeBridgeConfiguration : IEntityTypeConfiguration<UserIncomeBridge>
{
	public void Configure(EntityTypeBuilder<UserIncomeBridge> builder)
	{
		builder.HasKey(bridge => new { bridge.UserId, bridge.IncomeId });

		builder.HasOne(bridge => bridge.User)
			   .WithMany(user => user.UserIncomeBridges)
			   .HasForeignKey(bridge => bridge.UserId)
			   .IsRequired();

		builder.HasOne(bridge => bridge.Income)
			   .WithMany(income => income.UserIncomeBridges)
			   .HasForeignKey(bridge => bridge.IncomeId)
			   .IsRequired();
	}
}