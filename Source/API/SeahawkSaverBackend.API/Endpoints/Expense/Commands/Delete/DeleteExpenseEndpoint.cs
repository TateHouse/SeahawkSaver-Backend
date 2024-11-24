namespace SeahawkSaverBackend.API.Endpoints.Expense.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Delete;

/**
 * <summary>
 * An endpoint for deleting an existing <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> entity.
 * </summary>
 */
public static class DeleteExpenseEndpoint
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
		groupBuilder.MapDelete("/{userId}", DeleteExpenseEndpoint.HandleAsync)
					.AddEndpointFilter<UserTokenValidationFilter>()
					.WithName("Expense-Delete")
					.WithTags(tags)
					.WithSummary("An endpoint for deleting an existing expense from the database.")
					.WithDescription("For a user to delete an existing expense from the database, he must provide his user id and the expense id.")
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
	 * <param name="expenseId">The id of the expense to delete.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   [FromRoute] Guid userId,
												   [FromQuery] Guid expenseId)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = DeleteExpenseCommandFactory.Create(commandSettings, expenseId, userId);
			await mediator.Send(command);

			return Results.NoContent();
		}
		catch (NotFoundException)
		{
			return Results.NotFound();
		}
	}
}