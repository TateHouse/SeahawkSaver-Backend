namespace SeahawkSaverBackend.Application.UnitTest.Features.Debt.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Debt.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateDebtIdExtensionMethodTest : ExtensionMethodValidationTest<FakeDebtCommandRequest>
{
	protected override InlineValidator<FakeDebtCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeDebtCommandRequest>();
	}

	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(debt => debt.DebtId)
				 .ValidateDebtId();
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
					DebtId = Guid.Empty
				},
				ExpectedErrorPropertyName = nameof(FakeDebtCommandRequest.DebtId)
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
					DebtId = Guid.NewGuid()
				}
			};
		}
	}

}