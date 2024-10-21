﻿namespace SeahawkSaverBackend.Application.Features.User.Commands.Login;
using FluentValidation;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Commands.Login.DTOs;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="LoginUserCommand"/>.
 * </summary>
 */
public sealed class LoginUserCommandHandler : CommandHandler<LoginUserCommand, LoginUserCommandResponse>
{
	private readonly IPasswordHasher passwordHasher;
	private readonly ITokenGenerator tokenGenerator;

	/**
	 * <summary>
	 * Instantiates a new <see cref="LoginUserCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="passwordHasher">A password hasher.</param>
	 * <param name="tokenGenerator">A token generator.</param>
	 */
	public LoginUserCommandHandler(ICommandTransaction transaction,
								   IValidator<LoginUserCommand>? validator,
								   IPasswordHasher passwordHasher,
								   ITokenGenerator tokenGenerator)
		: base(transaction, validator)
	{
		this.passwordHasher = passwordHasher;
		this.tokenGenerator = tokenGenerator;
	}

	protected override async Task<LoginUserCommandResponse> HandleAsync(LoginUserCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetUserByEmailSpecification(request.Email);
		var user = await Transaction.UserRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException(nameof(User), request.Email);
		}

		var isPasswordValid = passwordHasher.Verify(request.Password, user.Password);

		if (isPasswordValid == false)
		{
			throw new UnauthorizedException("Invalid email or password.");
		}

		var token = tokenGenerator.GenerateToken(user);

		return new LoginUserCommandResponse
		{
			Token = token,
			User = new LoginUserCommandUserResponse
			{
				UserId = user.UserId,
				Email = user.Email
			}
		};
	}
}