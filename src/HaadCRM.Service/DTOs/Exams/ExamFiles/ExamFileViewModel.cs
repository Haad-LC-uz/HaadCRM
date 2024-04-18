using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.Exams;

namespace HaadCRM.Service.DTOs.ExamFiles;

public class ExamFileViewModel
{
    public long Id { get; set; }
    public ExamViewModel Exam { get; set; }
    public AssetViewModel Asset { get; set; }
}