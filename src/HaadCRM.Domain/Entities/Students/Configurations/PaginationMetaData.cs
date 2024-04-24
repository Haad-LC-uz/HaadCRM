namespace HaadCRM.Service.Configurations;

/// <summary>
/// The PaginationMetaData class represents the PaginationMetaData entity,
/// that contains properties for PaginationMetaData,
/// such as:
/// TotalPages
/// CurrentPage
/// HasPrevious
/// HasNext
/// </summary>
public class PaginationMetaData
{
    public PaginationMetaData(int totalCount, PaginationParams @params)
    {
        TotalPages = Convert.ToInt32(Math.Ceiling(totalCount / (decimal)@params.PageSize));
        CurrentPage = @params.PageIndex;
    }

    /// <summary>
    /// The TotalPages property represents the total Paginated pages
    /// </summary>
    public int TotalPages { get; set; }
    /// <summary>
    /// The CurrentPage property represents the Current Paginated page
    /// </summary>
    public int CurrentPage { get; set; }
    /// <summary>
    /// The HasPrevious property represents the status of paginated pages that has previous behind current page
    /// </summary>
    public bool HasPrevious => CurrentPage > 1;
    /// <summary>
    /// The HasNext property represents the status of paginated pages that has next ahead current page
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
}