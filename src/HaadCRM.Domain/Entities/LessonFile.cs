﻿using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class LessonFile : Auditable
{
    public long LessonId { get; set; }
    public string FilePath { get; set; }
}
