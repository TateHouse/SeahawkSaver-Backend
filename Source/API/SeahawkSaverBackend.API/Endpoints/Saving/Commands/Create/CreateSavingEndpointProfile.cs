namespace SeahawkSaverBackend.API.Endpoints.Saving.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Saving.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateSavingEndpoint"/>.
 * </summary>
 */
public sealed class CreateSavingEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSavingEndpointProfile"/> instance.
	 * </summary>
	 */
	public CreateSavingEndpointProfile()
	{
		CreateMap<CreateSavingCommandResponse, CreateSavingEndpointResponse>();
	}
}