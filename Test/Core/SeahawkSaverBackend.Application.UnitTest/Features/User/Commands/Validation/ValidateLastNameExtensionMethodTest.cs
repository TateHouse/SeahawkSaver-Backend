namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.User.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateLastNameExtensionMethodTest : ExtensionMethodValidationTest<FakeUserCommandRequest>
{
	protected override InlineValidator<FakeUserCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeUserCommandRequest>();
	}

	[SetUp]
	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(user => user.LastName)
				 .ValidateLastName();
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
					LastName = ""
				},
				ExpectedErrorPropertyName = nameof(FakeUserCommandRequest.LastName)
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
					LastName = "Test"
				}
			};
		}
	}
}