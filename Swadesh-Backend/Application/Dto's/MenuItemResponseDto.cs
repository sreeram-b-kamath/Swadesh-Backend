using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

    public class MenuItemResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Money { get; set; }
    public int Rating { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public string PrimaryImage { get; set; }

    public string Description { get; set; }
}
