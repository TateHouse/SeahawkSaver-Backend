namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Password.RequestReset;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Password.RequestReset.DTOs;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.RequestReset;

/**
 * <summary>
 * An endpoint for a user to request to reset his password.
 * </summary>
 */
public static class PasswordUserRequestResetEndpoint
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
		groupBuilder.MapPost("/request-reset-password", PasswordUserRequestResetEndpoint.HandleAsync)
					.WithName("User-Password-RequestReset")
					.WithTags(tags)
					.WithSummary("An endpoint for a user to request to reset his password.")
					.WithDescription("For a user to request to reset his password, he must be logged in and provide his email")
					.Produces(StatusCodes.Status200OK)
					.ProducesProblem(StatusCodes.Status404NotFound)
					.ProducesProblem(StatusCodes.Status401Unauthorized);
	}

	/**
	 * <summary>
	 * Asynchronously handles the endpoint.
	 * </summary>
	 * <param name="mediator">The mediator to use.</param>
	 * <param name="httpContext">The HTTP request with the token in the authorization header.</param>
	 * <param name="tokenExtractor">A token extractor.</param>
	 * <param name="tokenValidator">A token validator.</param>
	 * <param name="request">The data contained within the request body.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the endpoint's
	 * <see cref="IResult"/>.</returns>
	 */
	private async static Task<IResult> HandleAsync(IMediator mediator,
												   HttpContext httpContext,
												   ITokenExtractor tokenExtractor,
												   ITokenValidator tokenValidator,
												   [FromBody] PasswordUserRequestResetEndpointRequest request)
	{
		try
		{
			var token = tokenExtractor.ExtractToken(httpContext);
			await tokenValidator.ValidateTokenAsync(token, false, CancellationToken.None);
			var commandSettings = new CommandSettings(false, false);
			var command = PasswordUserRequestResetCommandFactory.Create(commandSettings, request.Email);
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