namespace SeahawkSaverBackend.Application.UnitTest.Utilities;
using FluentValidation;
using FluentValidation.TestHelper;

/**
 * <summary>
 * The base class for all validation extension method test fixture classes.
 * </summary>
 */
public abstract class ExtensionMethodValidationTest<TDTO>
	where TDTO : class
{
	/**
	 * <summary>
	 * The <see cref="InlineValidator{T}"/>.
	 * </summary>
	 */
	protected InlineValidator<TDTO> Validator { get; private set; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="InlineValidator{T}"/> instance of the derived type.
	 * </summary>
	 */
	protected abstract InlineValidator<TDTO> CreateValidator();

	[SetUp]
	public virtual void SetUp()
	{
		Validator = CreateValidator();
	}

	public virtual void GivenInvalidDTO_WhenValidate_ThenValidationResultContainsValidationError(ExtensionMethodValidationTestCase<TDTO> testCase)
	{
		var validationResult = Validator.TestValidate(testCase.DTO);

		if (testCase.ExpectedErrorPropertyName == null)
		{
			throw new InvalidOperationException($"The {nameof(ExtensionMethodValidationTestCase<TDTO>.ExpectedErrorPropertyName)} must be specified for invalid test cases.");
		}

		validationResult.ShouldHaveValidationErrorFor(testCase.ExpectedErrorPropertyName);
	}

	public virtual void GivenValidDTO_WhenValidate_ThenValidationResultContainsNoValidationErrors(ExtensionMethodValidationTestCase<TDTO> testCase)
	{
		var validationResult = Validator.TestValidate(testCase.DTO);
		validationResult.ShouldNotHaveAnyValidationErrors();
	}
}