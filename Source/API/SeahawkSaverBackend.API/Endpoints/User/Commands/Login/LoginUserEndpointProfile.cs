namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Login;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
using SeahawkSaverBackend.Application.Features.User.Commands.Login.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="LoginUserEndpoint"/>.
 * </summary>
 */
public sealed class LoginUserEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="LoginUserEndpointProfile"/> instance.
	 * </summary>
	 */
	public LoginUserEndpointProfile()
	{
		CreateMap<LoginUserCommandUserResponse, LoginUserEndpointUserResponse>();
		CreateMap<LoginUserCommandResponse, LoginUserEndpointResponse>();
	}
}