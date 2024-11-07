namespace SeahawkSaverBackend.API.Endpoints.Subscription;
using SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Create;

/**
 * <summary>
 * Maps the <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> related endpoints.
 * </summary>
 */
public static class SubscriptionEndpointsMapper
{
	/**
	 * <summary>
	 * The shared prefix for all <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> related endpoints.
	 * </summary>
	 */
	public const string Prefix = "/api/v1/subscription";
	private readonly static string[] Tags = { "Subscription" };

	/**
	 * <summary>
	 * An extension method for <see cref="WebApplication"/> to map the
	 * <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> releated endpoints.
	 * </summary>
	 */
	public static void MapSubscriptionEndpoints(this WebApplication application)
	{
		var groupBuilder = application.MapGroup(SubscriptionEndpointsMapper.Prefix);
        CreateSubscriptionEndpoint.MapEndpoint(groupBuilder, SubscriptionEndpointsMapper.Tags);
	}
}