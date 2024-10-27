namespace SeahawkSaverBackend.API.Endpoints.Income.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Income.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateIncomeEndpoint"/>.
 * </summary>
 */
public sealed class CreateIncomeEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateIncomeEndpointProfile"/> instance.
	 * </summary>
	 */
	public CreateIncomeEndpointProfile()
	{
		CreateMap<CreateIncomeCommandResponse, CreateIncomeEndpointResponse>();
	}
}