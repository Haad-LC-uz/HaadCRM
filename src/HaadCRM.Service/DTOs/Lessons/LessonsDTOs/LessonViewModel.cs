﻿namespace HaadCRM.Service.DTOs.Lessons;

public class LessonViewModel
{
    public long Id { get; set; }
    public long GroupId { get; set; }
    public DateTime DateOfLesson { get; set; }
    public string Name { get; set; }
}