using System.Collections.Generic;

namespace Shared;

public class Filters
{
    public int id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public string Icon { get; set; }
    public bool Active { get; set; }
}

public class FiltersDto
{
    public string languageCode { get; set; }
    public List<Filters> Filters { get; set; }
}