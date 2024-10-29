namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Income.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateIncomeIdExtensionMethodTest : ExtensionMethodValidationTest<FakeIncomeCommandRequest>
{
	protected override InlineValidator<FakeIncomeCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeIncomeCommandRequest>();
	}

	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(income => income.IncomeId)
				 .ValidateIncomeId();
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
					IncomeId = Guid.Empty
				},
				ExpectedErrorPropertyName = nameof(FakeIncomeCommandRequest.IncomeId)
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
					IncomeId = Guid.NewGuid()
				}
			};
		}
	}

}