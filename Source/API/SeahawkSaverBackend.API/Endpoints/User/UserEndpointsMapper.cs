namespace SeahawkSaverBackend.API.Endpoints.User;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login;

/**
 * <summary>
 * Maps the <see cref="SeahawkSaverBackend.Domain.Entities.User"/> related endpoints.
 * </summary>
 */
public static class UserEndpointsMapper
{
	/**
	 * <summary>The shared prefix for all <see cref="SeahawkSaverBackend.Domain.Entities.User"/> related endpoints.
	 * </summary>
	 */
	public const string Prefix = "/api/v1/user/";
	private readonly static string[] Tags = { "User" };

	/**
	 * <summary>
	 * An extension method for <see cref="WebApplication"/> to map the
	 * <see cref="SeahawkSaverBackend.Domain.Entities.User"/> releated enpoints.
	 * </summary>
	 */
	public static void MapUserEndpoints(this WebApplication application)
	{
		var groupBuilder = application.MapGroup(UserEndpointsMapper.Prefix);
		LoginUserEndpoint.MapEndpoint(groupBuilder, UserEndpointsMapper.Tags);
	}
}