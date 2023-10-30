namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BuberDinner.Domain.Entities;

    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
