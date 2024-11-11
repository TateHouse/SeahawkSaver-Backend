namespace SeahawkSaverBackend.API.Endpoints.Subscription.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Subscription.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.List;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.List.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed class ListSubscriptionEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSubscriptionEndpointProfile"/> instance.
	 * </summary>
	 */
	public ListSubscriptionEndpointProfile()
	{
		CreateMap<Guid, ListSubscriptionQuery>()
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));

		CreateMap<ListSubscriptionQuerySubscriptionResponse, ListSubscriptionEndpointSubscriptionResponse>();
		CreateMap<ListSubscriptionQueryResponse, ListSubscriptionEndpointResponse>();
	}
}