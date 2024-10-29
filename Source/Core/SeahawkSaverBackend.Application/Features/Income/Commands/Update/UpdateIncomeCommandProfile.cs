namespace SeahawkSaverBackend.Application.Features.Income.Commands.Update;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Income.Commands.Update.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="UpdateIncomeCommand"/>.
 * </summary>
 */
public sealed class UpdateIncomeCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateIncomeCommandProfile"/> instance.
	 * </summary>
	 */
	public UpdateIncomeCommandProfile()
	{
		CreateMap<UpdateIncomeCommandIncomeRequest, Income>()
			.ForMember(destinationMember => destinationMember.IncomeId,
					   memberOptions => memberOptions.Ignore())
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.Ignore());
	}
}