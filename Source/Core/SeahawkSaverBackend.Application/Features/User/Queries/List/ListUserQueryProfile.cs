namespace SeahawkSaverBackend.Application.Features.User.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Features.User.Queries.List.DTOs;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The AutoMapper <see cref="Profile"/> for the <see cref="ListUserQuery"/>.
 * </summary>
 */
public sealed class ListUserQueryProfile : Profile
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListUserQueryProfile"/> instance.
	 * </summary>
	 */
	public ListUserQueryProfile()
	{
		CreateMap<User, ListUserQueryUserResponse>();
		CreateMap<IEnumerable<User>, ListUserQueryResponse>()
			.ForMember(destinationMember => destinationMember.Users,
					   memberOptions => memberOptions.MapFrom(sourceMember => sourceMember));
	}
}