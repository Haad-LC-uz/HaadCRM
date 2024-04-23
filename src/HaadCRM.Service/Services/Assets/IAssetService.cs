using HaadCRM.Domain.Enums;
using HaadCRM.Service.DTOs.Assets;
using Microsoft.AspNetCore.Http;

namespace HaadCRM.Service.Services.Assets;

public interface IAssetService
{
    ValueTask<AssetViewModel> UploadAsync(IFormFile file, FileType type);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AssetViewModel> GetByIdAsync(long id);
}
