namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Delete;

/**
 * <summary>
 * An endpoint for deleting an existing <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entity.
 * </summary>
 */
public static class DeleteDebtEndpoint
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
		groupBuilder.MapDelete("/{userId}", DeleteDebtEndpoint.HandleAsync)
					.AddEndpointFilter<TokenValidationFilter>()
					.WithName("Debt-Delete")
					.WithTags(tags)
					.WithSummary("An endpoint for deleting an existing debt from the database.")
					.WithDescription("For a user to delete an existing debt from the database, he must provide his user id and the debt id.")
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
	 * <param name="debtId">The id of the debt to delete.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   [FromRoute] Guid userId,
												   [FromQuery] Guid debtId)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = DeleteDebtCommandFactory.Create(commandSettings, debtId, userId);
			await mediator.Send(command);

			return Results.NoContent();
		}
		catch (NotFoundException)
		{
			return Results.NotFound();
		}
	}
}