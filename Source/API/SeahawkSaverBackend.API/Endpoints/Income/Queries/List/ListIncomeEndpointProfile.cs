namespace SeahawkSaverBackend.API.Endpoints.Income.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Income.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Income.Queries.List;
using SeahawkSaverBackend.Application.Features.Income.Queries.List.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListIncomeEndpoint"/>.
 * </summary>
 */
public sealed class ListIncomeEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListIncomeEndpointProfile"/> instance.
	 * </summary>
	 */
	public ListIncomeEndpointProfile()
	{
		CreateMap<Guid, ListIncomeQuery>()
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));

		CreateMap<ListIncomeQueryIncomeResponse, ListIncomeEndpointIncomeResponse>();
		CreateMap<ListIncomeQueryResponse, ListIncomeEndpointResponse>();
	}
}