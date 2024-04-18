using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.Users.Users.UserDTOs;

namespace HaadCRM.Service.DTOs.Students.StudentDTOs;

public class StudentViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public AssetViewModel Asset { get; set; }
}
