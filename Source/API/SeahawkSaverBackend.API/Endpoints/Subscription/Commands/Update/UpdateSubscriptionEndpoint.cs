namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Update.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Update;

/**
 * <summary>
 * An endpoint for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> entity.
 * </summary>
 */
public static class UpdateSubscriptionEndpoint
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
		groupBuilder.MapPut("/{userId}", UpdateSubscriptionEndpoint.HandleAsync)
					.AddEndpointFilter<UserTokenValidationFilter>()
					.WithName("Subscription-Update")
					.WithTags(tags)
					.WithSummary("Updates all subscription properties.")
					.WithDescription("Since this is a PUT operation, all subscription properties must be provided for the update even if they are not modified.")
					.Produces(StatusCodes.Status204NoContent)
					.ProducesProblem(StatusCodes.Status404NotFound)
					.ProducesValidationProblem(StatusCodes.Status400BadRequest);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="request">The data contained within the request body.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   [FromRoute] Guid userId,
												   [FromBody] UpdateSubscriptionEndpointRequest request)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = UpdateSubscriptionCommandFactory.Create(commandSettings,
																  userId,
																  request.Subscription.SubscriptionId,
																  request.Subscription.Amount,
																  request.Subscription.DateTime);

			await mediator.Send(command);

			return Results.NoContent();
		}
		catch (ValidationException)
		{
			return Results.BadRequest();
		}
		catch (NotFoundException)
		{
			return Results.NotFound();
		}
	}
}