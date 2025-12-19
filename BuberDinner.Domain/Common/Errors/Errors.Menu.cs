using System;
using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Menu
    {
        public static Error NotFound => Error.Validation(
            code: "Menu.NotFound",
            description: "The requested menu does not exist."
        );
    }
}
