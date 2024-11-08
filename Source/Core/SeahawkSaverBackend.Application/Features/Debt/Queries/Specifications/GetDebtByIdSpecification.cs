namespace SeahawkSaverBackend.Application.Features.Debt.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving a <see cref="Debt"/> entity from the database by its <see cref="Debt.DebtId"/>
 * and its associated <see cref="User.UserId"/>.
 * </summary>
 */
public sealed class GetDebtByIdSpecification : SingleResultSpecification<Debt>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="GetDebtByIdSpecification"/> instance.
	 * </summary>
	 * <param name="debtId">The debt's id.</param>
	 * <param name="userId">The id of the associated user.</param>
	 */
	public GetDebtByIdSpecification(Guid debtId, Guid userId)
	{
		Query.Where(debt => debt.DebtId == debtId &&
							  debt.UserId == userId);
	}
}