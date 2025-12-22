using System;
using FluentValidation;

namespace BuberDinner.Application.Menus.Queries.GetMenu;

public class GetMenuQueryValidator: AbstractValidator<GetMenuQuery>
{
    public GetMenuQueryValidator()
    {
        RuleFor(x => x.Guid).NotEmpty();        
    }
}