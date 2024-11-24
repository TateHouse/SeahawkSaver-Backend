namespace SeahawkSaverBackend.API.Endpoints.Expense.Queries.List;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Expense.Queries.List.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Features.Expense.Queries.List;

/**
 * <summary>
 * An endpoint for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> entities from the database
 * for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public static class ListExpenseEndpoint
{
	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="groupBuilder">The builder for the route group.</param>
	 * <param name="tags">The tags to associate this endpoint with.</param>
	 */
	public static void MapEndpoint(RouteGroupBuilder groupBuilder, string[] tags)
	{
		groupBuilder.MapGet("/list{userId}", ListExpenseEndpoint.HandleAsync)
					.AddEndpointFilter<UserTokenValidationFilter>()
					.WithName("Expense-List")
					.WithTags(tags)
					.WithSummary("An endpoint for retrieving all expenses for the user.")
					.WithDescription("All of the user's associated expenses are returned.")
					.Produces<ListExpenseEndpointResponse>(StatusCodes.Status200OK)
					.ProducesProblem(StatusCodes.Status401Unauthorized);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="mapper">The mapper to use.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   IMapper mapper,
												   [FromRoute] Guid userId)
	{
		var query = mapper.Map<ListExpenseQuery>(userId);
		var response = mapper.Map<ListExpenseEndpointResponse>(await mediator.Send(query));

		return Results.Ok(response);
	}
}