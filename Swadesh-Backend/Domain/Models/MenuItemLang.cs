namespace Models;


public class MenuItemLang
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int MenuItemsId { get; set; }
    public MenuItem MenuItems { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}