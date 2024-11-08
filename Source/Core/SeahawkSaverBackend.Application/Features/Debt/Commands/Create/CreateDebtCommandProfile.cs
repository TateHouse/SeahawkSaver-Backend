namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateDebtCommand"/>.
 * </summary>
 */
public sealed class CreateDebtCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateDebtCommand"/> instance.
	 * </summary>
	 */
	public CreateDebtCommandProfile()
	{
		CreateMap<CreateDebtCommandDebtRequest, Debt>();
		CreateMap<Guid, CreateDebtCommandResponse>()
			.ForMember(destinationMember => destinationMember.DebtId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}