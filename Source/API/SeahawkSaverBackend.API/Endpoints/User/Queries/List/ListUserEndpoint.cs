namespace SeahawkSaverBackend.API.Endpoints.User.Queries.List;
using AutoMapper;
using MediatR;
using SeahawkSaverBackend.API.Endpoints.User.Queries.List.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Features.User.Queries.List;

/**
 * <summary>
 * An endpoint for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.User"/> entities from the database.
 * </summary>
 */
public static class ListUserEndpoint
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
		groupBuilder.MapGet("/list", HandleAsync)
					.AddEndpointFilter<AdminTokenValidationFilter>()
					.WithName("User-List")
					.WithTags(tags)
					.WithSummary("An endpoint for retrieving all users.")
					.WithDescription("This endpoint is meant only to be used by admins.")
					.Produces<ListUserEndpointResponse>(StatusCodes.Status200OK)
					.ProducesProblem(StatusCodes.Status401Unauthorized);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="mapper">The mapper to use.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   IMapper mapper)
	{
		var query = new ListUserQuery();
		var response = mapper.Map<ListUserEndpointResponse>(await mediator.Send(query));

		return Results.Ok(response);
	}
}