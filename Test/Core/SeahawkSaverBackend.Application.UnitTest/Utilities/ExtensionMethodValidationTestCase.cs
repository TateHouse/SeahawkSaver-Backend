namespace SeahawkSaverBackend.Application.UnitTest.Utilities;
/**
 * <summary>
 * A data transfer object for validation extension method test cases.
 * </summary>
 */
public sealed record ExtensionMethodValidationTestCase<TDTO>
	where TDTO : class
{
	public required TDTO DTO { get; init; }
	public string? ExpectedErrorPropertyName { get; init; }
}