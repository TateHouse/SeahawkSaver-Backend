namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Password.PerformReset;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Password.PerformReset.DTOs;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset;

public static class PasswordUserPerformResetEndpoint
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
		groupBuilder.MapPost("/perform-reset-password", PasswordUserPerformResetEndpoint.HandleAsync)
					.WithName("User-Password-PerformReset")
					.WithTags(tags)
					.WithSummary("An endpoint for a user to perform resetting his password.")
					.WithDescription("For a user to perform resetting his password, he must provide the authentication token provided by the password request reset endpoint and his updated password.")
					.Produces(StatusCodes.Status200OK)
					.ProducesProblem(StatusCodes.Status404NotFound)
					.ProducesProblem(StatusCodes.Status401Unauthorized);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="tokenValidator">A token validator.</param>
	 * <param name="request">The data contained within the request body.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   ITokenValidator tokenValidator,
												   [FromBody] PasswordUserPerformResetEndpointRequest request)
	{
		try
		{
			await tokenValidator.ValidateTokenAsync(request.Token, true, CancellationToken.None);
			var commandSettings = new CommandSettings(true, true);
			var command = PasswordUserPerformResetCommandFactory.Create(commandSettings, request.Token, request.Password);
			await mediator.Send(command);

			return Results.Ok();
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