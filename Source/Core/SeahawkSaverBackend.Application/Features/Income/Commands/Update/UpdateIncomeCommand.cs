namespace SeahawkSaverBackend.Application.Features.Income.Commands.Update;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Income.Commands.Update.DTOs;

/**
 * <summary>
 * A command for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> entity.
 * </summary>
 */
public sealed class UpdateIncomeCommand : Command<Unit>
{
	public required UpdateIncomeCommandIncomeRequest Income { get; init; }
}