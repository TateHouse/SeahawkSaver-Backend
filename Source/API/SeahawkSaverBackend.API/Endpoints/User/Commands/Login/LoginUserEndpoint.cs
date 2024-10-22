namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Login;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Commands.Login;

/**
 * <summary>
 * An endpoint for a user to log in to the application.
 * </summary>
 */
public static class LoginUserEndpoint
{
	/**
	 * <summary>
	 * Maps the endpoint.
	 * </summary>
	 * <param name="groupBuilder">The builder for the route group.</param>
	 * <param name="tags">The tags to associate this endpoint with.</param>
	 */
	public static void MapEndpoint(RouteGroupBuilder groupBuilder, string[] tags)
	{
		groupBuilder.MapPost("/", LoginUserEndpoint.HandleAsync)
					.WithName("User-Login")
					.WithTags(tags)
					.WithSummary("An endpoint for a user to login.")
					.WithDescription("For a user to login, a valid email and password must be provided.")
					.Produces<LoginUserEndpointResponse>(StatusCodes.Status200OK)
					.ProducesValidationProblem(StatusCodes.Status404NotFound)
					.ProducesProblem(StatusCodes.Status401Unauthorized);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="mapper">The mapper to use.</param>
	 * <param name="request">The data contained within the request body.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   IMapper mapper,
												   [FromBody] LoginUserEndpointRequest request)
	{
		try
		{
			var commandSettings = new CommandSettings(false, false);
			var command = LoginUserCommandFactory.Create(commandSettings, request.Email, request.Password);
			var response = mapper.Map<LoginUserEndpointResponse>(await mediator.Send(command));

			return Results.Ok(response);
		}
		catch (NotFoundException)
		{
			return Results.NotFound();
		}
		catch (UnauthorizedException)
		{
			return Results.Unauthorized();
		}
	}
}