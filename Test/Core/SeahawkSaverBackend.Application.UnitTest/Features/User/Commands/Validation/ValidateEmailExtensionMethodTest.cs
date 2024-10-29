namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.User.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateEmailExtensionMethodTest : ExtensionMethodValidationTest<FakeUserCommandRequest>
{
	protected override InlineValidator<FakeUserCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeUserCommandRequest>();
	}

	[SetUp]
	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(user => user.Email)
				 .ValidateEmail();
	}

	[Test]
	[TestCaseSource(nameof(InvalidDTOs))]
	public override void GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(ExtensionMethodValidationTestCase<FakeUserCommandRequest> testCase)
	{
		base.GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(testCase);
	}

	[Test]
	[TestCaseSource(nameof(ValidDTOs))]
	public override void GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(ExtensionMethodValidationTestCase<FakeUserCommandRequest> testCase)
	{
		base.GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(testCase);
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeUserCommandRequest>> InvalidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeUserCommandRequest>
			{
				DTO = new FakeUserCommandRequest
				{
					Email = string.Empty
				},
				ExpectedErrorPropertyName = nameof(FakeUserCommandRequest.Email)
			};

			yield return new ExtensionMethodValidationTestCase<FakeUserCommandRequest>
			{
				DTO = new FakeUserCommandRequest
				{
					Email = "test.email"
				},
				ExpectedErrorPropertyName = nameof(FakeUserCommandRequest.Email)
			};
		}
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeUserCommandRequest>> ValidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeUserCommandRequest>
			{
				DTO = new FakeUserCommandRequest
				{
					Email = "test.user@example.com"
				}
			};
		}
	}
}