namespace HaadCRM.Domain.Commons;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
}