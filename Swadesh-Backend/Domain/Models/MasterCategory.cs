using System.Collections.Generic;

namespace Models;

public class MasterCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DefaultOrder { get; set; }
    public ICollection<MasterCategoryLang> MasterCategoryLanguage { get; set; }
}