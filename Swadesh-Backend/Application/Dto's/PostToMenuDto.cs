using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public class PostToMenuDto
    {
        public string Name { get; set; }
        public string PrimaryImage { get; set; }
        public string Description { get; set; }
        public decimal Money { get; set; }
        public int RestaurantId { get; set; }  
        public int MenuCategoryId { get; set; }
        public int[] MenuFilterIds { get; set; }
        public bool Active { get; set; } 

        public List<int> IngredientIds { get; set; }
    }
}
