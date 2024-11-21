namespace SeahawkSaverBackend.Application.Features.Expense.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Expense.Queries.List.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListExpenseQuery"/>.
 * </summary>
 */
public sealed class ListExpenseQueryProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListExpenseQueryProfile"/> instance.
	 * </summary>
	 */
	public ListExpenseQueryProfile()
	{
		CreateMap<Expense, ListExpenseQueryExpenseResponse>();
		CreateMap<IEnumerable<Expense>, ListExpenseQueryResponse>()
			.ForMember(destinationMember => destinationMember.Expenses,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}