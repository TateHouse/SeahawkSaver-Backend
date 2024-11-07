namespace SeahawkSaverBackend.Application.UnitTest.Features.Saving.Commands.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Saving.Commands;
using SeahawkSaverBackend.Application.UnitTest.Utilities;

[TestFixture]
public sealed class ValidateAmountExtensionMethodTest : ExtensionMethodValidationTest<FakeSavingCommandRequest>
{

	protected override InlineValidator<FakeSavingCommandRequest> CreateValidator()
	{
		return new InlineValidator<FakeSavingCommandRequest>();
	}

	[SetUp]
	public override void SetUp()
	{
		base.SetUp();
		Validator.RuleFor(saving => saving.Amount)
				 .ValidateAmount();
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
					Amount = -1
				},
				ExpectedErrorPropertyName = nameof(FakeSavingCommandRequest.Amount)
			};

			yield return new ExtensionMethodValidationTestCase<FakeSavingCommandRequest>
			{
				DTO = new FakeSavingCommandRequest
				{
					Amount = 0
				},
				ExpectedErrorPropertyName = nameof(FakeSavingCommandRequest.Amount)
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
					Amount = 1
				}
			};
		}
	}
}