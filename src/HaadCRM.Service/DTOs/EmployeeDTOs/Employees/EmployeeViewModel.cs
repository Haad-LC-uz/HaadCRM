﻿using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles;
using HaadCRM.Service.DTOs.UserDTOs.Users;

namespace HaadCRM.Service.DTOs.EmployeeDTOs.Employees;

public class EmployeeViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public EmployeeRoleViewModel EmployeeRole { get; set; }
    public AssetViewModel Asset { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }
}