using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.Users;

namespace HaadCRM.Service.DTOs.Students;

public class StudentViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public AssetViewModel Asset { get; set; }
}
