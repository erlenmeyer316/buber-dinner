using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Domain.Entities;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Ensure use doesn't already exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Result.Fail<AuthenticationResult>(new[]  {new DuplicateEmailError()});
        }

        // Create user (generate unique id) & persist to database
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create jwt token        
        var token = _jwtTokenGenerator.GenerateToken(user);

        
        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Ensure user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doesn't exist");
        }

        // Validate the password
        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        // Create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }
}
