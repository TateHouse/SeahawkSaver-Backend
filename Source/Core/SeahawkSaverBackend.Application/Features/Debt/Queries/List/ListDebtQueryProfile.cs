namespace SeahawkSaverBackend.Application.Features.Debt.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Debt.Queries.List.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListDebtQuery"/>.
 * </summary>
 */
public sealed class ListDebtQueryProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListDebtQueryProfile"/> instance.
	 * </summary>
	 */
	public ListDebtQueryProfile()
	{
		CreateMap<Debt, ListDebtQueryDebtResponse>();
		CreateMap<IEnumerable<Debt>, ListDebtQueryResponse>()
			.ForMember(destinationMember => destinationMember.Debts,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}