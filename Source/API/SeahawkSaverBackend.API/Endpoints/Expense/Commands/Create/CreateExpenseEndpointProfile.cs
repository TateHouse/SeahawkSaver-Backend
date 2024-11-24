namespace SeahawkSaverBackend.API.Endpoints.Expense.Commands.Create;
using AutoMapper;
using SeahawkSaverBackend.API.Endpoints.Expense.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Create.DTOs;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="CreateExpenseEndpoint"/>.
 * </summary>
 */
public sealed class CreateExpenseEndpointProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateExpenseEndpointProfile"/> instance.
	 * </summary>
	 */
	public CreateExpenseEndpointProfile()
	{
		CreateMap<CreateExpenseCommandResponse, CreateExpenseEndpointResponse>();
	}
}