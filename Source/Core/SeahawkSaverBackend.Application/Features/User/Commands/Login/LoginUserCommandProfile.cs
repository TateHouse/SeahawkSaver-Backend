namespace SeahawkSaverBackend.Application.Features.User.Commands.Login;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.User.Commands.Login.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="LoginUserCommand"/>.
 * </summary>
 */
public sealed class LoginUserCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="LoginUserCommandProfile"/> instance.
	 * </summary>
	 */
	public LoginUserCommandProfile()
	{
		CreateMap<User, LoginUserCommandUserResponse>();
	}
}