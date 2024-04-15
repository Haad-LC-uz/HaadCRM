﻿using HaadCRM.Domain.Enums;

namespace HaadCRM.Service.DTOs.Employees;

public class EmployeeViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }
    public string PicturePath { get; set; }
    public Role Role { get; set; }
}