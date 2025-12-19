using System;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.Entities;
using BuberDinner.Domain.Menus.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
           
        
        // Create user (generate unique id) & persist to database
        var menu = Menu.Create(            
            HostId.Create(new Guid(request.HostId)),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(sections => MenuSection.Create(
                sections.Name,
                sections.Description,
                sections.Items.ConvertAll(items => MenuItem.Create(
                    items.Name,
                    items.Description
                )))));

        _menuRepository.Add(menu);

        return menu;
    }
}
