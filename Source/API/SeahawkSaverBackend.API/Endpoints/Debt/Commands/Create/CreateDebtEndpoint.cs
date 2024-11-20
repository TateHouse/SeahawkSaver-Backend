namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create.DTOs;
using SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create;

/**
 * <summary>
 * An endpoint for creating a new <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entity.
 * </summary>
 */
public static class CreateDebtEndpoint
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
		groupBuilder.MapPost("/{userId}", CreateDebtEndpoint.HandleAsync)
					.AddEndpointFilter<UserTokenValidationFilter>()
					.WithName("Debt-Create")
					.WithTags(tags)
					.WithSummary("An endpoint for adding a new debt to the database.")
					.WithDescription("For a user to add a new debt to the database, his user id, the amount, and the date and time must be provided.")
					.Produces<CreateDebtEndpointResponse>(StatusCodes.Status201Created)
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
												   [FromBody] CreateDebtEndpointRequest request)
	{
		try
		{
			var commandSettings = new CommandSettings(true, true);
			var command = CreateDebtCommandFactory.Create(commandSettings,
															userId,
															request.Debt.Amount,
															request.Debt.DateTime);

			var response = mapper.Map<CreateDebtEndpointResponse>(await mediator.Send(command));
			var uri = $"{DebtEndpointsMapper.Prefix}/{response.DebtId}";

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