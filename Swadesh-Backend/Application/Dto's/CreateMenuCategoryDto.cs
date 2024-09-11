using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public class CreateMenuCategoryDto
    {
        public string Name { get; set; }    
        public bool Active { get; set; }
        public int RestaurantId { get; set; }

    }
}
