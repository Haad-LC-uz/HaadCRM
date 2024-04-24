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

    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}