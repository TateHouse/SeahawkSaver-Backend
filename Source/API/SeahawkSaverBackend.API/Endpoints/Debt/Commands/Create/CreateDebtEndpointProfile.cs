namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateDebtEndpoint"/>.
 * </summary>
 */
public sealed class CreateDebtEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateDebtEndpointProfile"/> instance.
	 * </summary>
	 */
	public CreateDebtEndpointProfile()
	{
		CreateMap<CreateDebtCommandResponse, CreateDebtEndpointResponse>();
	}
}