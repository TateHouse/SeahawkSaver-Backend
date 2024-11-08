namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Update.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Update;

/**
 * <summary>
 * An endpoint for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entity.
 * </summary>
 */
public static class UpdateDebtEndpoint
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
		groupBuilder.MapPut("/{userId}", UpdateDebtEndpoint.HandleAsync)
					.AddEndpointFilter<TokenValidationFilter>()
					.WithName("Debt-Update")
					.WithTags(tags)
					.WithSummary("Updates all debt properties.")
					.WithDescription("Since this is a PUT operation, all debt properties must be provided for the update even if they are not modified.")
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
												   [FromBody] UpdateDebtEndpointRequest request)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = UpdateDebtCommandFactory.Create(commandSettings,
															userId,
															request.Debt.DebtId,
															request.Debt.Amount,
															request.Debt.DateTime);

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