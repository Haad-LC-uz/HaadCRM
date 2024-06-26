﻿using HaadCRM.Domain.Enums;

namespace HaadCRM.Domain.Commons;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public FileType FileType { get; set; }
}