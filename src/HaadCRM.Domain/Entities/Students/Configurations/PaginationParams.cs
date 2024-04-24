namespace HaadCRM.Service.Configurations;

/// <summary>
/// The PaginationParams class represents the PaginationParams entity that contains properties for PaginationParams,
/// such as:
/// PageIndex
/// PageSize
/// </summary>
public class PaginationParams
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
