namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateIncomeCommand"/>.
 * </summary>
 */
public sealed class CreateIncomeCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateIncomeCommandProfile"/> instance.
	 * </summary>
	 */
	public CreateIncomeCommandProfile()
	{
		CreateMap<CreateIncomeCommandIncomeRequest, Income>();
		CreateMap<Guid, CreateIncomeCommandResponse>()
			.ForMember(destinationMember => destinationMember.IncomeId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}