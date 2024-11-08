namespace SeahawkSaverBackend.API.Endpoints.Debt.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Debt.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Debt.Queries.List;
using SeahawkSaverBackend.Application.Features.Debt.Queries.List.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListDebtEndpoint"/>.
 * </summary>
 */
public sealed class ListDebtEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListDebtEndpointProfile"/> instance.
	 * </summary>
	 */
	public ListDebtEndpointProfile()
	{
		CreateMap<Guid, ListDebtQuery>()
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));

		CreateMap<ListDebtQueryDebtResponse, ListDebtEndpointDebtResponse>();
		CreateMap<ListDebtQueryResponse, ListDebtEndpointResponse>();
	}
}