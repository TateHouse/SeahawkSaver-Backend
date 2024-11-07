namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateSavingCommand"/>.
 * </summary>
 */
public sealed class CreateSavingCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSavingCommandProfile"/> instance.
	 * </summary>
	 */
	public CreateSavingCommandProfile()
	{
		CreateMap<CreateSavingCommandSavingRequest, Saving>();
		CreateMap<Guid, CreateSavingCommandResponse>()
			.ForMember(destinationMember => destinationMember.SavingId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}