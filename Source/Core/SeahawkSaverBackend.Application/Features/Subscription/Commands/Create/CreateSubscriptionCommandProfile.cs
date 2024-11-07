namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateSubscriptionCommand"/>.
 * </summary>
 */
public sealed class CreateSubscriptionCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSubscriptionCommand"/> instance.
	 * </summary>
	 */
	public CreateSubscriptionCommandProfile()
	{
		CreateMap<CreateSubscriptionCommandSubscriptionRequest, Subscription>();
		CreateMap<Guid, CreateSubscriptionCommandResponse>()
			.ForMember(destinationMember => destinationMember.SubscriptionId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}