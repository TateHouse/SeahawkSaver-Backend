namespace SeahawkSaverBackend.API.Endpoints.Saving.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Saving.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Saving.Queries.List;
using SeahawkSaverBackend.Application.Features.Saving.Queries.List.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListSavingEndpoint"/>.
 * </summary>
 */
public sealed class ListSavingEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSavingEndpointProfile"/> instance.
	 * </summary>
	 */
	public ListSavingEndpointProfile()
	{
		CreateMap<Guid, ListSavingQuery>()
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));

		CreateMap<ListSavingQuerySavingResponse, ListSavingEndpointSavingResponse>();
		CreateMap<ListSavingQueryResponse, ListSavingEndpointResponse>();
	}
}