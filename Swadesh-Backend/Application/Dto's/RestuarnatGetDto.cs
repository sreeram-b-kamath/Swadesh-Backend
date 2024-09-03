using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos;

public class RestuarantUserGetDto
{
    public int Id { get; set; }
    public string Uid { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public string Logo { get; set; }
    public string Cuisine { get; set; }
    public string Contact { get; set; }
    public bool Active { get; set; }
    public bool InitialLogin { get; set; }
    public int UserId { get; set; }
    
}
