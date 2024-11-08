namespace SeahawkSaverBackend.Application.UnitTest.Features.Saving.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Saving.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateUserIdExtensionMethodTest : ExtensionMethodValidationTest<FakeSavingCommandRequest>
{
	protected override InlineValidator<FakeSavingCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeSavingCommandRequest>();
	}

	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(saving => saving.UserId)
				 .ValidateUserId();
	}

	[Test]
	[TestCaseSource(nameof(InvalidDTOs))]
	public override void GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(ExtensionMethodValidationTestCase<FakeSavingCommandRequest> testCase)
	{
		base.GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(testCase);
	}

	[Test]
	[TestCaseSource(nameof(ValidDTOs))]
	public override void GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(ExtensionMethodValidationTestCase<FakeSavingCommandRequest> testCase)
	{
		base.GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(testCase);
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeSavingCommandRequest>> InvalidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeSavingCommandRequest>
			{
				DTO = new FakeSavingCommandRequest
				{
					UserId = Guid.Empty
				},
				ExpectedErrorPropertyName = nameof(FakeSavingCommandRequest.UserId)
			};
		}
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeSavingCommandRequest>> ValidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeSavingCommandRequest>
			{
				DTO = new FakeSavingCommandRequest
				{
					UserId = Guid.NewGuid()
				}
			};
		}
	}
}