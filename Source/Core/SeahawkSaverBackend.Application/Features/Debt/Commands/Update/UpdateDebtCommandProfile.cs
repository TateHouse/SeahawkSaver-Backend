namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Update;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Update.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="UpdateDebtCommand"/>.
 * </summary>
 */
public sealed class UpdateDebtCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateDebtCommandProfile"/> instance.
	 * </summary>
	 */
	public UpdateDebtCommandProfile()
	{
		CreateMap<UpdateDebtCommandDebtRequest, Debt>()
			.ForMember(destinationMember => destinationMember.DebtId,
					   memberOptions => memberOptions.Ignore())
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.Ignore());
	}
}