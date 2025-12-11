using System;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Ensure user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authenication.InvalidCredentials;
        }

        // Validate the password
        if (user.Password != query.Password)
        {
            return Errors.Authenication.InvalidCredentials;
        }

        // Create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return await Task.FromResult(new AuthenticationResult(user,token));
    }
}
