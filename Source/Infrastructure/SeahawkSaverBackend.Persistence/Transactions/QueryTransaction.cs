namespace SeahawkSaverBackend.Persistence.Transactions;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The "unit of work" for queries.
 * </summary>
 */
public sealed class QueryTransaction : IQueryTransaction
{
	public IReadOnlyRepository<User> UserRepository { get; }
	public IReadOnlyRepository<Income> IncomeRepository { get; }
	public IReadOnlyRepository<Debt> DebtRepository { get; }
	public IReadOnlyRepository<Saving> SavingRepository { get; }
	public IReadOnlyRepository<Subscription> SubscriptionRepository { get; }
	public IReadOnlyRepository<Expense> ExpenseRepository { get; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="QueryTransaction"/> instance.
	 * </summary>
	 * <param name="userRepository">A read-only repository for <see cref="User"/> entities.</param>
	 * <param name="incomeRepository">A read-only repository for <see cref="Income"/> entities.</param>
	 * <param name="debtRepository">A read-only repository for <see cref="Debt"/> entities.</param>
	 * <param name="savingRepository">A read-only repository for <see cref="Saving"/> entities.</param>
	 * <param name="subscriptionRepository">A read-only repository for <see cref="Subscription"/> entities.</param>
	 * <param name="expenseRepository">A read-only repository for <see cref="Expense"/> entities.</param>
	 */
	public QueryTransaction(IReadOnlyRepository<User> userRepository,
							IReadOnlyRepository<Income> incomeRepository,
							IReadOnlyRepository<Debt> debtRepository,
							IReadOnlyRepository<Saving> savingRepository,
							IReadOnlyRepository<Subscription> subscriptionRepository,
							IReadOnlyRepository<Expense> expenseRepository)
	{
		UserRepository = userRepository;
		IncomeRepository = incomeRepository;
		DebtRepository = debtRepository;
		SavingRepository = savingRepository;
		SubscriptionRepository = subscriptionRepository;
		ExpenseRepository = expenseRepository;
	}
}