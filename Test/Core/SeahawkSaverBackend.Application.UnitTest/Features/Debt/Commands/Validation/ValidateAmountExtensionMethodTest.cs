namespace SeahawkSaverBackend.Application.UnitTest.Features.Debt.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Debt.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateAmountExtensionMethodTest : ExtensionMethodValidationTest<FakeDebtCommandRequest>
{
	protected override InlineValidator<FakeDebtCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeDebtCommandRequest>();
	}

	[SetUp]
	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(debt => debt.Amount)
				 .ValidateAmount();
	}

	[Test]
	[TestCaseSource(nameof(InvalidDTOs))]
	public override void GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(ExtensionMethodValidationTestCase<FakeDebtCommandRequest> testCase)
	{
		base.GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(testCase);
	}

	[Test]
	[TestCaseSource(nameof(ValidDTOs))]
	public override void GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(ExtensionMethodValidationTestCase<FakeDebtCommandRequest> testCase)
	{
		base.GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(testCase);
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeDebtCommandRequest>> InvalidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeDebtCommandRequest>
			{
				DTO = new FakeDebtCommandRequest
				{
					Amount = -1
				},
				ExpectedErrorPropertyName = nameof(FakeDebtCommandRequest.Amount)
			};

			yield return new ExtensionMethodValidationTestCase<FakeDebtCommandRequest>
			{
				DTO = new FakeDebtCommandRequest
				{
					Amount = 0
				},
				ExpectedErrorPropertyName = nameof(FakeDebtCommandRequest.Amount)
			};
		}
	}

	public static IEnumerable<ExtensionMethodValidationTestCase<FakeDebtCommandRequest>> ValidDTOs
	{
		get
		{
			yield return new ExtensionMethodValidationTestCase<FakeDebtCommandRequest>
			{
				DTO = new FakeDebtCommandRequest
				{
					Amount = 1
				}
			};
		}
	}
}