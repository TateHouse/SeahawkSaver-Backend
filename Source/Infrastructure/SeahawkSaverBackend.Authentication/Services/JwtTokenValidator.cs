namespace SeahawkSaverBackend.Authentication.Services;
using Microsoft.IdentityModel.Tokens;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

/**
 * <summary>
 * A JSON web token validator.
 * </summary>
 */
public sealed class JwtTokenValidator : ITokenValidator
{
	private readonly TokenValidationParameters tokenValidationParameters;
	private readonly IReadOnlyRepository<User> userRepository;

	/**
	 * <summary>
	 * Instantiates a new <see cref="JwtTokenValidator"/> instance.
	 * </summary>
	 * <param name="tokenValidationParameters">The parameters to validate the token against.</param>
	 * <param name="userRepository">A read-only user repository.</param>
	 */
	public JwtTokenValidator(TokenValidationParameters tokenValidationParameters,
							 IReadOnlyRepository<User> userRepository)
	{
		this.tokenValidationParameters = tokenValidationParameters;
		this.userRepository = userRepository;
	}

	public async Task<User> ValidateTokenAsync(string token, CancellationToken cancellationToken)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		try
		{
			var claimsPrinciple = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

			if (validatedToken is not JwtSecurityToken)
			{
				throw new UnauthorizedException("The token failed to validate as a JWT.");
			}

			var userIdClaim = claimsPrinciple.FindFirst(ClaimTypes.NameIdentifier);

			if (userIdClaim == null)
			{
				throw new UnauthorizedException("The user's name identifier was not found.");
			}

			var userId = Guid.Parse(userIdClaim.Value);
			var specification = new GetUserByIdSpecification(userId);
			var user = await userRepository.SingleOrDefaultAsync(specification, cancellationToken);

			if (user == null)
			{
				throw new NotFoundException(nameof(User), nameof(userId));
			}

			return user;
		}
		catch (NotFoundException exception)
		{
			throw;
		}
		catch (Exception exception)
		{
			throw new UnauthorizedException(exception.Message, exception);
		}
	}
}