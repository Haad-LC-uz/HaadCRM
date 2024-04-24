namespace HaadCRM.Service.Configurations;

/// <summary>
/// The PaginationParams class represents the PaginationParams entity that contains properties for PaginationParams,
/// such as:
/// PageIndex
/// PageSize
/// </summary>
public class PaginationParams
{
    /// <summary>
    /// The PageIndex property represents What index of the paginated data
    /// </summary>
    public int PageIndex { get; set; } = 1;
    /// <summary>
    /// The PageSiz property represents What size of the paginated data
    /// </summary>
    public int PageSize { get; set; } = 20;
}
