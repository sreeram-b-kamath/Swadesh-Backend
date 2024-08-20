namespace Models;


public class MenuCategoryLang
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int MenuCategoryId { get; set; }
    public MenuCategory MenuCategory { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}
