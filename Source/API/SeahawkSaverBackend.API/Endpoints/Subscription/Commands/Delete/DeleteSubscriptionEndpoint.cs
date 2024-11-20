namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Income.Commands.Delete;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Delete;

/**
 * <summary>
 * An endpoint for deleting an existing <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> entity.
 * </summary>
 */
public static class DeleteSubscriptionEndpoint
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
		groupBuilder.MapDelete("/{userId}", DeleteSubscriptionEndpoint.HandleAsync)
					.AddEndpointFilter<UserTokenValidationFilter>()
					.WithName("Delete-Subscription")
					.WithTags(tags)
					.WithSummary("An endpoint for deleting an existing subscription endpoint from the database.")
					.WithDescription("For a user to delete an existing subscription from the database, he must provide his user id and the subscription id.")
					.Produces(StatusCodes.Status204NoContent)
					.ProducesProblem(StatusCodes.Status401Unauthorized)
					.ProducesProblem(StatusCodes.Status404NotFound);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="subscriptionId">The id of the subscription to delete.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   [FromRoute] Guid userId,
												   [FromQuery] Guid subscriptionId)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = DeleteSubscriptionCommandFactory.Create(commandSettings, subscriptionId, userId);
			await mediator.Send(command);

			return Results.NoContent();
		}
		catch (NotFoundException)
		{
			return Results.NotFound();
		}
	}
}