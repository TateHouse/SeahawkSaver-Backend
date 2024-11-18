namespace SeahawkSaverBackend.Application.Features.User.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.User"/> data provided in the
 * request for the <see cref="UpdateUserCommand"/>.
 * </summary>
 */
public sealed record UpdateUserCommandUserRequest : UserCommandRequest
{
	public required Guid UserId { get; init; }
	public required string Email { get; init; }
	public required string FirstName { get; init; }
	public required string LastName { get; init; }
	public required bool IsActive { get; init; }
}