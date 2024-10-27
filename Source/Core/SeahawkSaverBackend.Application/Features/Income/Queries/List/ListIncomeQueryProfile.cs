namespace SeahawkSaverBackend.Application.Features.Income.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Income.Queries.List.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListIncomeQuery"/>.
 * </summary>
 */
public sealed class ListIncomeQueryProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListIncomeQueryProfile"/> instance.
	 * </summary>
	 */
	public ListIncomeQueryProfile()
	{
		CreateMap<Income, ListIncomeQueryIncomeResponse>();
		CreateMap<IEnumerable<Income>, ListIncomeQueryResponse>()
			.ForMember(destinationMember => destinationMember.Incomes,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}