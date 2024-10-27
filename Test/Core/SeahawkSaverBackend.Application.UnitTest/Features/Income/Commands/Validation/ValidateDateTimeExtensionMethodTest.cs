namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Income.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateDateTimeExtensionMethodTest : ExtensionMethodValidationTest<FakeIncomeCommandRequest>
{
	protected override InlineValidator<FakeIncomeCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeIncomeCommandRequest>();
	}

	[SetUp]
	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(income => income.DateTime)
				 .ValidateDateTime();
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
					DateTime = DateTime.Now.AddDays(1)
				},
				ExpectedErrorPropertyName = nameof(FakeIncomeCommandRequest.DateTime)
			};

			yield return new ExtensionMethodValidationTestCase<FakeIncomeCommandRequest>
			{
				DTO = new FakeIncomeCommandRequest
				{
					DateTime = DateTime.Now.AddDays(-31)
				},
				ExpectedErrorPropertyName = nameof(FakeIncomeCommandRequest.DateTime)
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
					DateTime = DateTime.Now
				}
			};

			yield return new ExtensionMethodValidationTestCase<FakeIncomeCommandRequest>
			{
				DTO = new FakeIncomeCommandRequest
				{
					DateTime = DateTime.Now.AddDays(-7)
				}
			};

		}
	}
}