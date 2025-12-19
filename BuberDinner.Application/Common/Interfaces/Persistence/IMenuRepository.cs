using System;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
    List<Menu>? GetMenusByHostId(HostId id);
    Menu? GetMenuById(MenuId id);
}
