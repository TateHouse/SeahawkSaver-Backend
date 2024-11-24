namespace SeahawkSaverBackend.API.Endpoints.Expense;
using SeahawkSaverBackend.API.Endpoints.Expense.Queries.List;

/**
 * <summary>
 * Maps the <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> related endpoints.
 * </summary>
 */
public static class ExpenseEndpointMapper
{
	/**
	 * <summary>
	 * The shared prefix for all <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> related endpoints.
	 * </summary>
	 */
	public const string Prefix = "/api/v1/expense";
	private readonly static string[] Tags = { "Expense" };

	/**
	 * <summary>
	 * An extension method for <see cref="WebApplication"/> to map the
	 * <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> releated endpoints.
	 * </summary>
	 */
	public static void MapExpenseEndpoints(this WebApplication application)
	{
		var groupBuilder = application.MapGroup(ExpenseEndpointMapper.Prefix);
		ListExpenseEndpoint.MapEndpoint(groupBuilder, ExpenseEndpointMapper.Tags);
	}
}