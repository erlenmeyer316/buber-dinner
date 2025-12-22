using System;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class MenuMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => HostId.Create(Guid.Parse(src.HostId)))
            .Map(dest => dest, src => src.Request);    

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(id => id.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(id => id.Value));


        config.NewConfig<Domain.Menus.Entities.MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Domain.Menus.Entities.MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

    }
}
