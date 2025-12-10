using System;
using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    DateTime IDateTimeProvider.UtcNow => DateTime.UtcNow;
}
