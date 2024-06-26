﻿using HaadCRM.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace HaadCRM.Service.DTOs.Assets;

public class AssetCreateModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}