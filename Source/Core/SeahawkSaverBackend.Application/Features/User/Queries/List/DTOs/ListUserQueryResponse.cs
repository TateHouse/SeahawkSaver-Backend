namespace SeahawkSaverBackend.Application.Features.User.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListUserQuery"/>.
 * </summary>
 */
public sealed record ListUserQueryResponse
{
	public required IReadOnlyList<ListUserQueryUserResponse> Users { get; init; }
}