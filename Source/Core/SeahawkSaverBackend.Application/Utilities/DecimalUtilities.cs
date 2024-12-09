namespace SeahawkSaverBackend.Application.Utilities;
/**
 * <summary>
 * A collection of <see cref="Decimal"/> utility methods.
 * </summary>
 */
public static class DecimalUtilities
{
	/**
	 * <summary>
	 * Generates a random decimal with the specified range.
	 * </summary>
	 * <param name="random">The range generator to use.</param>
	 * <param name="minimum">The minimum.</param>
	 * <param name="maximum">The maximum.</param>
	 * <returns>A decimal within the specified range.</returns>
	 */
	public static decimal Generate(Random random, double minimum, double maximum)
	{
		var minimumScaled = (int)(minimum * 100);
		var maximumScaled = (int)(maximum * 100);
		var randomScaled = random.Next(minimumScaled, maximumScaled + 1);
		var randomDecimal = randomScaled / 100.0m;

		return Math.Round(randomDecimal, 2);
	}
}