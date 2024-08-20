using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Models;

namespace Shared.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }
    public DbSet<User> users { get; set; }
    public DbSet<Restaurant> restaurants { get; set; }
    public DbSet<MasterCategory> masterCategories { get; set; }
    public DbSet<MasterCategoryLang> masterCategoryLangs { get; set; }
    public DbSet<MasterFilter> masterFilters { get; set; }
    public DbSet<MasterFilterLang> masterFilterLangs { get; set; }
    public DbSet<MenuCategory> menuCategories { get; set; }
    public DbSet<MenuFilter> menuFilters { get; set; }
    public DbSet<MenuItem> menuItems { get; set; }
    public DbSet<MenuCategoryLang> menuCategoryLangs { get; set; }
    public DbSet<MenuFilterLang> menuFilterLangs { get; set; }
    public DbSet<MenuItemLang> menuItemLangs { get; set; }
    public DbSet<RestaurantDetails> restaurantDetails { get; set; }
    public DbSet<MenuItemRating> menuItemRatings { get; set; }
    public DbSet<ErrorMessage> errorMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new RestaurantConfig());
        modelBuilder.ApplyConfiguration(new MasterCategoryConfig());
        modelBuilder.ApplyConfiguration(new MasterCategoryLangConfig());
        modelBuilder.ApplyConfiguration(new MasterFilterConfig());
        modelBuilder.ApplyConfiguration(new MasterFilterLangConfig());
        modelBuilder.ApplyConfiguration(new MenuCategoryConfig());
        modelBuilder.ApplyConfiguration(new MenuFilterConfig());
        modelBuilder.ApplyConfiguration(new MenuItemConfig());
        modelBuilder.ApplyConfiguration(new MenuCategoryLangConfig());
        modelBuilder.ApplyConfiguration(new MenuFilterLangConfig());
        modelBuilder.ApplyConfiguration(new MenuItemLangConfig());
        modelBuilder.ApplyConfiguration(new RestaurantDetailsConfig());
        modelBuilder.ApplyConfiguration(new MenuItemRatingConfig());
    }
}
