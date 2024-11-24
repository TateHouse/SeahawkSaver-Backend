namespace SeahawkSaverBackend.Application.Features.Expense.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving a <see cref="Expense"/> entity from the database by its <see cref="Expense.ExpenseId"/>
 * and its associated <see cref="User.UserId"/>.
 * </summary>
 */
public sealed class GetExpenseByIdSpecification : SingleResultSpecification<Expense>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="GetExpenseByIdSpecification"/> instance.
	 * </summary>
	 * <param name="expenseId">The expense's id.</param>
	 * <param name="userId">The id of the associated user.</param>
	 */
	public GetExpenseByIdSpecification(Guid expenseId, Guid userId)
	{
		Query.Where(expense => expense.ExpenseId == expenseId &&
							   expense.UserId == userId);
	}
}