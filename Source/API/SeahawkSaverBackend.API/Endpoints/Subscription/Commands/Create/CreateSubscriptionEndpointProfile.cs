namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed class CreateSubscriptionEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSubscriptionEndpointProfile"/> instance.
	 * </summary>
	 */
	public CreateSubscriptionEndpointProfile()
	{
		CreateMap<CreateSubscriptionCommandResponse, CreateSubscriptionEndpointResponse>();
	}
}