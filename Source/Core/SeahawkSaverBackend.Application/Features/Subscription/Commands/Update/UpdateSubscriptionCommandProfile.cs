namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Update;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Update.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="UpdateSubscriptionCommand"/>.
 * </summary>
 */
public sealed class UpdateSubscriptionCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSubscriptionCommandProfile"/> instance.
	 * </summary>
	 */
	public UpdateSubscriptionCommandProfile()
	{
		CreateMap<UpdateSubscriptionCommandSubscriptionRequest, Subscription>()
			.ForMember(destinationMember => destinationMember.SubscriptionId,
					   memberOptions => memberOptions.Ignore())
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.Ignore());
	}
}