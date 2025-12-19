using System;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetMenu;

public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public GetMenuQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Ensure user exists
        if (_menuRepository.GetMenuById(MenuId.Create(request.Guid)) is not Menu menu)
        {
            return Errors.Menu.NotFound;
        }
        
        return menu;
    }
}
