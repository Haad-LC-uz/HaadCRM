﻿namespace HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;

public class GroupStudentCreateModel
{
    public long GroupId { get; set; }
    public long StudentId { get; set; }
    public bool IsPaid { get; set; }
    public bool IsPassed { get; set; }
}
