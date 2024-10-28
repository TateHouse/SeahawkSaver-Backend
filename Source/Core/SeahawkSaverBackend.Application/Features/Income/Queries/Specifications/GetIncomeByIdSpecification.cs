namespace SeahawkSaverBackend.Application.Features.Income.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving a <see cref="Income"/> entity from the database by its <see cref="Income.IncomeId"/>
 * and its associated <see cref="User.UserId"/>.
 * </summary>
 */
public sealed class GetIncomeByIdSpecification : SingleResultSpecification<Income>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="GetIncomeByIdSpecification"/> instance.
	 * </summary>
	 * <param name="incomeId">The income's id.</param>
	 * <param name="userId">The id of the associated user.</param>
	 */
	public GetIncomeByIdSpecification(Guid incomeId, Guid userId)
	{
		Query.Where(income => income.IncomeId == incomeId &&
							  income.UserId == userId);
	}
}