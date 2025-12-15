using System;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuItemId : Common.Models.ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
