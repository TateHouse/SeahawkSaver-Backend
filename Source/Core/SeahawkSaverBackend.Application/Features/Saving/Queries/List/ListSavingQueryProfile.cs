namespace SeahawkSaverBackend.Application.Features.Saving.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Saving.Queries.List.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListSavingQuery"/>.
 * </summary>
 */
public sealed class ListSavingQueryProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSavingQueryProfile"/> isntance.
	 * </summary>
	 */
	public ListSavingQueryProfile()
	{
		CreateMap<Saving, ListSavingQuerySavingResponse>();
		CreateMap<IEnumerable<Saving>, ListSavingQueryResponse>()
			.ForMember(destinationMember => destinationMember.Savings,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}