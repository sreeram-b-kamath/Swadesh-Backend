using System.Collections.Generic;

namespace Models;

public class MasterFilter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icons { get; set; }
    public int DefaultOrder { get; set; }
    public ICollection<MasterFilterLang> MasterFilterLanguage { get; set; }
}