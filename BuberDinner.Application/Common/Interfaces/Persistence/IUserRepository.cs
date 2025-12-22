using System;
using BuberDinner.Domain.Users;

namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
