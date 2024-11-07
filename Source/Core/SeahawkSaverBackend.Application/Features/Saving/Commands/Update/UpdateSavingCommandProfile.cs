namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Update;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Update.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="UpdateSavingCommand"/>.
 * </summary>
 */
public sealed class UpdateSavingCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSavingCommandProfile"/> instance.
	 * </summary>
	 */
	public UpdateSavingCommandProfile()
	{
		CreateMap<UpdateSavingCommandSavingRequest, Saving>()
			.ForMember(destinationMember => destinationMember.SavingId,
					   memberOptions => memberOptions.Ignore())
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.Ignore());
	}
}