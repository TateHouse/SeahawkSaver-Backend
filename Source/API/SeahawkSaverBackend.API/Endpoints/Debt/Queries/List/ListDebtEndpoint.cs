namespace SeahawkSaverBackend.API.Endpoints.Debt.Queries.List;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Debt.Queries.List.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Features.Debt.Queries.List;

/**
 * <summary>
 * An endpoint for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entities from the database
 * for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public static class ListDebtEndpoint
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
		groupBuilder.MapGet("/list/{userId}", ListDebtEndpoint.HandleAsync)
					.AddEndpointFilter<TokenValidationFilter>()
					.WithName("Debt-List")
					.WithTags(tags)
					.WithSummary("An endpoint for retrieving all debt for the user.")
					.WithDescription("All of the user's associated debt is returned.")
					.Produces<ListDebtEndpointResponse>(StatusCodes.Status200OK)
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
		var query = mapper.Map<ListDebtQuery>(userId);
		var response = mapper.Map<ListDebtEndpointResponse>(await mediator.Send(query));

		return Results.Ok(response);
	}
}