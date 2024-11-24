namespace SeahawkSaverBackend.API.Endpoints.Expense.Commands.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Expense.Commands.Create.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Create;

/**
 * <summary>
 * An endpoint for creating a new <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> entity.
 * </summary>
 */
public static class CreateExpenseEndpoint
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
		groupBuilder.MapPost("/{userId}", CreateExpenseEndpoint.HandleAsync)
					.AddEndpointFilter<UserTokenValidationFilter>()
					.WithName("Expense-Create")
					.WithTags(tags)
					.WithSummary("An endpoint for adding a new expense to the database.")
					.WithDescription("For a user to add a new expense to the database, his user id, the amount, and the date and time must be provided.")
					.Produces<CreateExpenseEndpointResponse>(StatusCodes.Status201Created)
					.ProducesProblem(StatusCodes.Status401Unauthorized)
					.ProducesProblem(StatusCodes.Status404NotFound)
					.ProducesValidationProblem(StatusCodes.Status400BadRequest);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="mapper">The mapper to use.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="request">The data contained within the request body.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   IMapper mapper,
												   [FromRoute] Guid userId,
												   [FromBody] CreateExpenseEndpointRequest request)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = CreateExpenseCommandFactory.Create(commandSettings,
															 userId,
															 request.Expense.Amount,
															 request.Expense.DateTime);

			var response = mapper.Map<CreateExpenseEndpointResponse>(await mediator.Send(command));
			var uri = $"{ExpenseEndpointMapper.Prefix}/{response.ExpenseId}";

			return Results.Created(uri, response);
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