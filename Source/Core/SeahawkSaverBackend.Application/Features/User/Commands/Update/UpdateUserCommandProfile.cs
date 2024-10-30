namespace SeahawkSaverBackend.Application.Features.User.Commands.Update;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.User.Commands.Update.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="UpdateUserCommand"/>.
 * </summary>
 */
public sealed class UpdateUserCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateUserCommandProfile"/> instance.
	 * </summary>
	 */
	public UpdateUserCommandProfile()
	{
		CreateMap<UpdateUserCommandUserRequest, User>()
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.Ignore());
	}
}