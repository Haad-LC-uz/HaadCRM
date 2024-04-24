using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Enums;
using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Helpers;
using Microsoft.AspNetCore.Http;

namespace HaadCRM.Service.Services.Assets;

public class AssetService(IMapper mapper, IUnitOfWork unitOfWork) : IAssetService
{
    public async ValueTask<AssetViewModel> UploadAsync(IFormFile file, FileType type)
    {
        var directoryPath = Path.Combine(EnvironmentHelper.WebRootPath, type.ToString());
        Directory.CreateDirectory(directoryPath);

        var fullPath = Path.Combine(directoryPath, file.FileName);

        using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);
        await stream.FlushAsync();
        stream.Close();

        var asset = new Asset()
        {
            Path = fullPath,
            Name = file.FileName
        };

        var createdAsset = await unitOfWork.Assets.InsertAsync(asset);
        await unitOfWork.SaveAsync();

        return mapper.Map<AssetViewModel>(asset);
    }


    public async ValueTask<bool> DeleteAsync(long id)
    {
        var asset = await unitOfWork.Assets.SelectAsync(a => a.Id == id)
          ?? throw new NotFoundException($"Asset is not found with this id: {id}");

        var deletedAsset = await unitOfWork.Assets.DropAsync(asset);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<AssetViewModel> GetByIdAsync(long id)
    {
        var asset = await unitOfWork.Assets.SelectAsync(a => a.Id == id)
            ?? throw new NotFoundException($"Asset is not found with this id: {id}");

        return mapper.Map<AssetViewModel>(asset);
    }
}
