namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Income.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateUserIdExtensionMethodTest : ExtensionMethodValidationTest<FakeIncomeCommandRequest>
{
	protected override InlineValidator<FakeIncomeCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeIncomeCommandRequest>();
	}

	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(income => income.UserId)
				 .ValidateUserId();
	}

	[Test]
	[TestCaseSource(nameof(InvalidDTOs))]
	public override void GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(ExtensionMethodValidationTestCase<FakeIncomeCommandRequest> testCase)
	{
		base.GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(testCase);
	}

	[Test]
	[TestCaseSource(nameof(ValidDTOs))]
	public override void GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(ExtensionMethodValidationTestCase<FakeIncomeCommandRequest> testCase)
	{
		base.GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(testCase);
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeIncomeCommandRequest>> InvalidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeIncomeCommandRequest>
			{
				DTO = new FakeIncomeCommandRequest
				{
					UserId = Guid.Empty
				},
				ExpectedErrorPropertyName = nameof(FakeIncomeCommandRequest.UserId)
			};
		}
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeIncomeCommandRequest>> ValidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeIncomeCommandRequest>
			{
				DTO = new FakeIncomeCommandRequest
				{
					UserId = Guid.NewGuid()
				}
			};
		}
	}
}