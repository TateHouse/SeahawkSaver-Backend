namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Validation;
using SeahawkSaverBackend.Application.Features.User.Commands;

public sealed record FakeUserCommandRequest : UserCommandRequest
{
	public Guid? UserId { get; init; }
	public string? Email { get; init; }
	public string? Password { get; init; }
	public string? FirstName { get; init; }
	public string? LastName { get; init; }
}