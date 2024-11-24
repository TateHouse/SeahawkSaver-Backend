namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Create.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateExpenseCommand"/>.
 * </summary>
 */
public sealed class CreateExpenseCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateExpenseCommand"/> instance.
	 * </summary>
	 */
	public CreateExpenseCommandProfile()
	{
		CreateMap<CreateExpenseCommandExpenseRequest, Expense>();
		CreateMap<Guid, CreateExpenseCommandResponse>()
			.ForMember(destinationMember => destinationMember.ExpenseId,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}