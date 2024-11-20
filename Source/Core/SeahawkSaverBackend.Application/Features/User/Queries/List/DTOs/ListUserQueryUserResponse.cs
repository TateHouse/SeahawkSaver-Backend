namespace SeahawkSaverBackend.Application.Features.User.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.User"/> data provided in
 * the response for the <see cref="ListUserQuery"/>.
 * </summary>
 */
public sealed record ListUserQueryUserResponse
{
	public required Guid UserId { get; init; }
	public required string Email { get; init; }
	public required string FirstName { get; init; }
	public required string LastName { get; init; }
	public required bool IsAdmin { get; init; }
	public required bool IsActive { get; init; }
}