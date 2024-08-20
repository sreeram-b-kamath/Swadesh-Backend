namespace Models;

public class MasterCategoryLang
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int MasterCategoryId { get; set; }
    public MasterCategory MasterCategory { get; set; }
}