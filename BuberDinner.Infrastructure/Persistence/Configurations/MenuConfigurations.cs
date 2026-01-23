using System;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.Entities;
using BuberDinner.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, di =>
        {
            di.ToTable("MenuReviewIds");

            di.WithOwner().HasForeignKey(nameof(MenuId));


            di.HasKey("Id");

            di.Property(d => d.Value)
            .HasColumnName(nameof(MenuReviewId))
            .ValueGeneratedNever();


        });
        
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, di =>
        {
            di.ToTable("MenuDinnerIds");

            di.WithOwner().HasForeignKey(nameof(MenuId));


            di.HasKey("Id");

            di.Property(d => d.Value)
            .HasColumnName(nameof(DinnerId))
            .ValueGeneratedNever();


        });
        
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey(nameof(MenuId));

            sb.HasKey(nameof(Menu.Id), nameof(MenuId) );

            sb.Property(s => s.Id)
            .HasColumnName(nameof(MenuSectionId))
            .ValueGeneratedNever()
            .HasConversion(
              id => id.Value,
              value => MenuSectionId.Create(value)
            );


            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey(nameof(MenuSectionId), nameof(MenuId));

                ib.HasKey(nameof(MenuItem.Id), nameof(MenuSectionId), nameof(MenuId));

                ib.Property(i => i.Id)
                    .HasColumnName(nameof(MenuItemId))
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                ib.Property(i => i.Name)
                    .HasMaxLength(100);

                ib.Property(i => i.Description)
                    .HasMaxLength(100);

            });
            
            sb.Property(s => s.Name)
            .HasMaxLength(100);

            sb.Property(s => s.Description)
            .HasMaxLength(100);

            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });
        
        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => MenuId.Create(value)
        );

        builder.Property(m => m.Name)
        .HasMaxLength(100);

        builder.Property(m => m.Description)
        .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
        .HasConversion(
            id => id.Value,
            value => HostId.Create(value)
        );
    }
}
