using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Exams;

/// <summary>
/// The ExamFile class represents the File of exam that contains properties for Examfile,
/// such as:
/// ExamId 
/// AssetId
/// Exam
/// Asset
/// </summary>
public class ExamFile : Auditable
{
    /// <summary>
    /// The ExamId property represents the Id of the Exam
    /// </summary>
    public long ExamId { get; set; }
    /// <summary>
    /// The AssetId property represents the Id of the AssetId
    /// </summary>
    public long AssetId { get; set; }
    /// <summary>
    /// The Exam property represents the Exam object
    /// </summary>
    public Exam Exam { get; set; }
    /// <summary>
    /// The Asset property repre
    /// </summary>
    public Asset Asset { get; set; }
}