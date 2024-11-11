namespace SeahawkSaverBackend.Application.Features.Subscription.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.List.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListSubscriptionQuery"/>.
 * </summary>
 */
public sealed class ListSubscriptionQueryProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSubscriptionQueryProfile"/> instance.
	 * </summary>
	 */
	public ListSubscriptionQueryProfile()
	{
		CreateMap<Subscription, ListSubscriptionQuerySubscriptionResponse>();
		CreateMap<IEnumerable<Subscription>, ListSubscriptionQueryResponse>()
			.ForMember(destinationMember => destinationMember.Subscriptions,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}