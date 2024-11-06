namespace SeahawkSaverBackend.API.Endpoints.Saving;
using SeahawkSaverBackend.API.Endpoints.Saving.Commands.Delete;
using SeahawkSaverBackend.API.Endpoints.Saving.Queries.List;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Delete;

/**
 * <summary>
 * Maps the <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> related endpoints.
 * </summary>
 */
public static class SavingEndpointsMapper
{
	/**
	 * <summary>
	 * The shared prefix for all <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> related endpoints.
	 * </summary>
	 */
	public const string Prefix = "/api/v1/saving";
	private readonly static string[] Tags = { "Saving" };

	/**
	 * <summary>
	 * An extension method for <see cref="WebApplication"/> to map the
	 * <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> releated endpoints.
	 * </summary>
	 */
	public static void MapSavingEndpoints(this WebApplication application)
	{
		var groupBuilder = application.MapGroup(SavingEndpointsMapper.Prefix);
		DeleteSavingEndpoint.MapEndpoint(groupBuilder, SavingEndpointsMapper.Tags);
		ListSavingEndpoint.MapEndpoint(groupBuilder, SavingEndpointsMapper.Tags);
	}
}