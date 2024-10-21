namespace SeahawkSaverBackend.Application.Features.User.Commands.Login.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="LoginUserCommand"/>.
 * </summary>
 */
public sealed record LoginUserCommandResponse
{
	public required string Token { get; init; }
	public required LoginUserCommandUserResponse User { get; init; }
}