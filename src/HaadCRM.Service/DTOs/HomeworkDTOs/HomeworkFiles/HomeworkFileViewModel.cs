using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;

namespace HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;

public class HomeworkFileViewModel
{
    public long Id { get; set; }
    public HomeworkViewModel Homework { get; set; }
    public AssetViewModel Asset { get; set; }
}