namespace SeahawkSaverBackend.API.Endpoints.Expense.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Expense.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Expense.Queries.List;
using SeahawkSaverBackend.Application.Features.Expense.Queries.List.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListExpenseEndpoint"/>.
 * </summary>
 */
public sealed class ListExpenseEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListExpenseEndpointProfile"/> instance.
	 * </summary>
	 */
	public ListExpenseEndpointProfile()
	{
		CreateMap<Guid, ListExpenseQuery>()
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));

		CreateMap<ListExpenseQueryExpenseResponse, ListExpenseEndpointExpenseResponse>();
		CreateMap<ListExpenseQueryResponse, ListExpenseEndpointResponse>();
	}
}