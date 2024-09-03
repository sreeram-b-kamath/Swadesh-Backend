using Domain.Models;
using Infrastructure.EntityConfigs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Shared.Data;

public class ApplicationDBContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }
    public DbSet<Restaurant> restaurants { get; set; }
    public DbSet<MasterFilter> masterFilters { get; set; }
    public DbSet<MasterFilterLang> masterFilterLangs { get; set; }
    public DbSet<MenuCategory> menuCategories { get; set; }
    public DbSet<MenuFilter> menuFilters { get; set; }
    public DbSet<MenuItem> menuItems { get; set; }
    public DbSet<MenuCategoryLang> menuCategoryLangs { get; set; }
    public DbSet<MenuFilterLang> menuFilterLangs { get; set; }
    public DbSet<MenuItemLang> menuItemLangs { get; set; }
    public DbSet<RestaurantLang> restaurantLangs { get; set; }
    public DbSet<MenuItemRating> menuItemRatings { get; set; }
    public DbSet<ErrorMessage> errorMessages { get; set; }
    public DbSet<Ingredients> Ingredients { get; set; }
    public DbSet<MenuItemIngredients> MenuItemIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new RestaurantConfig());
        modelBuilder.ApplyConfiguration(new MasterFilterConfig());
        modelBuilder.ApplyConfiguration(new MasterFilterLangConfig());
        modelBuilder.ApplyConfiguration(new MenuCategoryConfig());
        modelBuilder.ApplyConfiguration(new MenuFilterConfig());
        modelBuilder.ApplyConfiguration(new MenuItemConfig());
        modelBuilder.ApplyConfiguration(new MenuCategoryLangConfig());
        modelBuilder.ApplyConfiguration(new MenuFilterLangConfig());
        modelBuilder.ApplyConfiguration(new MenuItemLangConfig());
        modelBuilder.ApplyConfiguration(new RestaurantLangsConfig());
        modelBuilder.ApplyConfiguration(new MenuItemRatingConfig());
        modelBuilder.ApplyConfiguration(new MenuItemIngredientConfig());
        modelBuilder.ApplyConfiguration(new IngredientConfig());

    }
}



