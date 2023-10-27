namespace BuberDinner.Application.Common.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
