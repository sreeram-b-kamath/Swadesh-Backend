namespace Models;


public class RestaurantDetails
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}