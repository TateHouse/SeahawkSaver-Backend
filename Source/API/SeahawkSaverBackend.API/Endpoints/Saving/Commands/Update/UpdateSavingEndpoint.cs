namespace SeahawkSaverBackend.API.Endpoints.Saving.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Saving.Commands.Update.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Update;

/**
 * <summary>
 * An endpoint for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> entity.
 * </summary>
 */
public static class UpdateSavingEndpoint
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
		groupBuilder.MapPut("/{userId}", UpdateSavingEndpoint.HandleAsync)
					.AddEndpointFilter<UserTokenValidationFilter>()
					.WithName("Saving-Update")
					.WithTags(tags)
					.WithSummary("Updates all saving properties.")
					.WithDescription("Since this is a PUT operation, all saving properties must be provided for the update even if they are not modified.")
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
												   [FromBody] UpdateSavingEndpointRequest request)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = UpdateSavingCommandFactory.Create(commandSettings,
															userId,
															request.Saving.SavingId,
															request.Saving.Amount,
															request.Saving.DateTime);

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