namespace SeahawkSaverBackend.API.Endpoints.Income.Queries.List;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Income.Queries.List.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Features.Income.Queries.List;

/**
 * <summary>
 * An endpoint for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> entities from the database
 * for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public static class ListIncomeEndpoint
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
		groupBuilder.MapGet("/list/{userId}", ListIncomeEndpoint.HandleAsync)
					.AddEndpointFilter<TokenValidationFilter>()
					.WithName("Income-List")
					.WithTags(tags)
					.WithSummary("An endpoint for retrieving all income for the user.")
					.WithDescription("All of the user's associated income is returned.")
					.Produces<ListIncomeEndpointResponse>(StatusCodes.Status200OK)
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
		var query = mapper.Map<ListIncomeQuery>(userId);
		var response = mapper.Map<ListIncomeEndpointResponse>(await mediator.Send(query));

		return Results.Ok(response);
	}
}