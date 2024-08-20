namespace Models;

public class MasterFilterLang
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int MasterFilterId { get; set; }
    public MasterFilter MasterFilter { get; set; }
}