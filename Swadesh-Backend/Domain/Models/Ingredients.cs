using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string image { get; set; }

        public ICollection<MenuItemIngredients> MenuItemIngredients { get; set; }
    }
}
