using System;

namespace Models;

public class MenuItemRating
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string SessionId { get; set; }
    public int Rating { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}