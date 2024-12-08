namespace SeahawkSaverBackend.Application.Utilities;
/**
 * A collection of <see cref="DateTime"/> utility methods.
 */
public static class DateTimeUtilities
{
	/**
	 * <summary>
	 * Generate a collection of <see cref="DateTime"/> with random days in the given year and month.
	 * </summary>
	 * <param name="random">The range generator to use.</param>
	 * <param name="year">The year.</param>
	 * <param name="month">The month.</param>
	 * <param name="count">The number to generate.</param>
	 * <returns>An enumerable of <see cref="DateTime"/>.</returns>
	 */
	public static IEnumerable<DateTime> Generate(Random random, int year, int month, int count)
	{
		var dateTimes = new List<DateTime>(count);
		var daysInMonth = DateTime.DaysInMonth(year, month);

		for (var index = 0; index < count; ++index)
		{
			var isDayValid = false;
			var randomDay = random.Next(1, daysInMonth + 1);
			var dateTime = new DateTime(year, month, randomDay);
			dateTimes.Add(dateTime);
		}

		return dateTimes;
	}
}