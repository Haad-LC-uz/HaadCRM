using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Commons;
using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Helpers;

namespace HaadCRM.Service.Services.Assets;

public class AssetService(IMapper mapper, IUnitOfWork unitOfWork) : IAssetService
{
    public async ValueTask<AssetViewModel> UploadAsync(AssetCreateModel asset)
    {
        var assetData = await FileHelper.CreateFileAsync(asset.File, asset.FileType);
        var existAsset = new Asset()
        {
            Name = assetData.Name,
            Path = assetData.Path,
        };

        var createdAsset = await unitOfWork.Assets.InsertAsync(existAsset);
        await unitOfWork.SaveAsync();

        return mapper.Map<AssetViewModel>(createdAsset);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
            ?? throw new NotFoundException("Asset is not found");

        await unitOfWork.Assets.DropAsync(existAsset);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<AssetViewModel> GetByIdAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
            ?? throw new NotFoundException("Asset is not found");

        return mapper.Map<AssetViewModel>(existAsset);
    }
}
