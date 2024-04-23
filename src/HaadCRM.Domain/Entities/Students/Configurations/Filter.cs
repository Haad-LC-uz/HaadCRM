namespace HaadCRM.Service.Configurations;

public class Filter
{
    /// <summary>
    /// The OrderBy property represents the value that can be ordered in the filter by this
    /// </summary>
    public string OrderBy { get; set; }
    /// <summary>
    /// The OrderType property represents the type of the order than can be in the filter according to this type
    /// </summary>
    public string OrderType { get; set; }
}