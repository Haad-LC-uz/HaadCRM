﻿namespace HaadCRM.Service.DTOs.EmployeeDTOs.Employees;


public class EmployeeCreateModel
{
    public long UserId { get; set; }
    public long EmployeeRoleId { get; set; }
    public long AssetId { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }
}