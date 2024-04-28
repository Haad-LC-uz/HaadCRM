using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.ExamDTOs.Exams;

namespace HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;

public class ExamFileViewModel
{
    public AssetViewModel Asset { get; set; }
    public ExamViewModel Exam { get; set; }
}