namespace SeahawkSaverBackend.API.Endpoints.User.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.User.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.User.Queries.List.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListUserEndpoint"/>.
 * </summary>
 */
public sealed class ListUserEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListUserEndpointProfile"/> instance.
	 * </summary>
	 */
	public ListUserEndpointProfile()
	{
		CreateMap<ListUserQueryUserResponse, ListUserEndpointUserResponse>();
		CreateMap<ListUserQueryResponse, ListUserEndpointResponse>();
	}
}