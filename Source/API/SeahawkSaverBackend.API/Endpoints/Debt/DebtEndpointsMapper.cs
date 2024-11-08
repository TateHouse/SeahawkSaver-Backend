namespace SeahawkSaverBackend.API.Endpoints.Debt;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Delete;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Update;
using SeahawkSaverBackend.API.Endpoints.Debt.Queries.List;

/**
 * <summary>
 * Maps the <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> related endpoints.
 * </summary>
 */
public static class DebtEndpointsMapper
{
	/**
	 * <summary>
	 * The shared prefix for all <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> related endpoints.
	 * </summary>
	 */
	public const string Prefix = "/api/v1/debt";
	private readonly static string[] Tags = { "Debt" };

	/**
	 * <summary>
	 * An extension method for <see cref="WebApplication"/> to map the
	 * <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> releated endpoints.
	 * </summary>
	 */
	public static void MapDebtEndpoints(this WebApplication application)
	{
		var groupBuilder = application.MapGroup(DebtEndpointsMapper.Prefix);
		CreateDebtEndpoint.MapEndpoint(groupBuilder, DebtEndpointsMapper.Tags);
		UpdateDebtEndpoint.MapEndpoint(groupBuilder, DebtEndpointsMapper.Tags);
		DeleteDebtEndpoint.MapEndpoint(groupBuilder, DebtEndpointsMapper.Tags);
		ListDebtEndpoint.MapEndpoint(groupBuilder, DebtEndpointsMapper.Tags);
	}
}