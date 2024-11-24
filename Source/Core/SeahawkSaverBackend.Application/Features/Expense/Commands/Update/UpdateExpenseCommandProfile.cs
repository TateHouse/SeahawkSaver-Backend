namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Update;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Update.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="UpdateExpenseCommand"/>.
 * </summary>
 */
public sealed class UpdateExpenseCommandProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateExpenseCommandProfile"/> instance.
	 * </summary>
	 */
	public UpdateExpenseCommandProfile()
	{
		CreateMap<UpdateExpenseCommandExpenseRequest, Expense>()
			.ForMember(destinationMember => destinationMember.ExpenseId,
					   memberOptions => memberOptions.Ignore())
			.ForMember(destinationMember => destinationMember.UserId,
					   memberOptions => memberOptions.Ignore());
	}
}