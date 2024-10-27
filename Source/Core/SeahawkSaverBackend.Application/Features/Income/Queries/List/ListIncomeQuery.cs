namespace SeahawkSaverBackend.Application.Features.Income.Queries.List;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Features.Income.Queries.List.DTOs;

/**
 * <summary>
 * A query for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> entities from the database with
 * a subset of properties.
 * </summary>
 */
public sealed class ListIncomeQuery : Query<ListIncomeQueryResponse>
{

}