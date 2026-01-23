using System;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }

    public Menu? GetMenuById(MenuId id)
    {
        throw new NotImplementedException();
    }

    public List<Menu>? GetMenusByHostId(HostId id)
    {
        throw new NotImplementedException();
    }
}
