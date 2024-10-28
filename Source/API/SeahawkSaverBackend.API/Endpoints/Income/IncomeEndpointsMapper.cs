namespace SeahawkSaverBackend.API.Endpoints.Income;
using SeahawkSaverBackend.API.Endpoints.Income.Commands.Create;
using SeahawkSaverBackend.API.Endpoints.Income.Commands.Delete;
using SeahawkSaverBackend.API.Endpoints.Income.Queries.List;

/**
 * <summary>
 * Maps the <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> related endpoints.
 * </summary>
 */
public static class IncomeEndpointsMapper
{
	/**
	 * <summary>
	 * The shared prefix for all <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> related endpoints.
	 * </summary>
	 */
	public const string Prefix = "/api/v1/income";
	private readonly static string[] Tags = { "Income" };

	/**
	 * <summary>
	 * An extension method for <see cref="WebApplication"/> to map the
	 * <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> releated endpoints.
	 * </summary>
	 */
	public static void MapIncomeEndpoints(this WebApplication application)
	{
		var groupBuilder = application.MapGroup(IncomeEndpointsMapper.Prefix);
		CreateIncomeEndpoint.MapEndpoint(groupBuilder, IncomeEndpointsMapper.Tags);
		DeleteIncomeEndpoint.MapEndpoint(groupBuilder, IncomeEndpointsMapper.Tags);
		ListIncomeEndpoint.MapEndpoint(groupBuilder, IncomeEndpointsMapper.Tags);
	}
}