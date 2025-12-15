using System;
using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
