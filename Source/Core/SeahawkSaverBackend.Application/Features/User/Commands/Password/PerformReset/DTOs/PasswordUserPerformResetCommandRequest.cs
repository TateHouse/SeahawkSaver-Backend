namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset.DTOs;
/**
 * <summary>
 * A data transfer object containing the data provided in the request for the
 * <see cref="PasswordUserPerformResetCommand"/>.
 * </summary>
 */
public sealed record PasswordUserPerformResetCommandRequest : UserCommandRequest
{
	public required string Token { get; init; }
	public required string Password { get; init; }
}