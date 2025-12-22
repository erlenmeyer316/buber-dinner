using System;
using BuberDinner.Domain.Menus;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetMenu;

public record GetMenuQuery(
    Guid Guid) : IRequest<ErrorOr<Menu>>;

