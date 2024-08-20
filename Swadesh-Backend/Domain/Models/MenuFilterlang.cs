namespace Models;


public class MenuFilterLang
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int MenuFiltersId { get; set; }
    public MenuFilter MenuFilters { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}