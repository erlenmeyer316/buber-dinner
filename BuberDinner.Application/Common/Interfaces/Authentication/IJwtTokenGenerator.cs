namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    using BuberDinner.Domain.Entities;

    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
