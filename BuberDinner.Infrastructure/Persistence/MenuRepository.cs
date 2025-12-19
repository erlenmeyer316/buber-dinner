using System;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }

    public List<Menu>? GetMenusByHostId(HostId hostId)
    {
       return _menus.FindAll(x => x.HostId == hostId).ToList();
    }

    public Menu? GetMenuById(MenuId menuId)
    {
        return _menus.SingleOrDefault(x => x.Id == menuId);
    }
}
