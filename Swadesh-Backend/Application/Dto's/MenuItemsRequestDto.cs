using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public class MenuItemsRequest
{
    public int RestaurantId { get; set; }
    public int[] FilterIds { get; set; }
}