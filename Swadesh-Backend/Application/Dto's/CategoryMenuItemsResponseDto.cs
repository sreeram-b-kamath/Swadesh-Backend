using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

    public class CategoryMenuItemsResponseDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public List<MenuItemResponse> MenuItems { get; set; }
}
