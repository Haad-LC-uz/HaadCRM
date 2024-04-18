using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.Homeworks;

namespace HaadCRM.Service.DTOs.HomeworkFiles;

public class HomeworkFileViewModel
{
    public long Id { get; set; }
    public HomeworkViewModel Homework { get; set; }
    public AssetViewModel Asset { get; set; }
}