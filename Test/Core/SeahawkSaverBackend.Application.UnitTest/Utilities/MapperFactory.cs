namespace SeahawkSaverBackend.Application.UnitTest.Utilities;
using AutoMapper;

/**
 * <summary>
 * A factory for creating AutoMapper mappers that implement <see cref="IMapper"/>.
 * </summary>
 */
public static class MapperFactory
{
	/**
	 * <summary>
	 * Instantiates an AutoMapper mapper with the specified <see cref="Profile"/> type.
	 * </summary>
	 * <typeparam name="TProfile">The type of the <see cref="Profile"/> to add to the mapper.</typeparam>
	 * <returns>An AutoMapper mapper.</returns>
	 */
	public static IMapper Create<TProfile>()
		where TProfile : Profile, new()
	{
		var configuration = new MapperConfiguration(configure =>
		{
			configure.AddProfile<TProfile>();
		});

		return configuration.CreateMapper();
	}

	/**
	 * <summary>
	 * Instantiates an AutoMapper mapper with all the specified <see cref="Profile"/> instances.
	 * </summary>
	 * <param name="profiles">An array of the <see cref="Profile"/> instances to add to the mapper.</param>
	 * <returns>An AutoMapper mapper.</returns>
	 */
	public static IMapper Create(Profile[] profiles)
	{
		var configuration = new MapperConfiguration(configure =>
		{
			foreach (var profile in profiles)
			{
				configure.AddProfile(profile);
			}
		});

		return configuration.CreateMapper();
	}
}