using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Homework.HomeworkFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace HaadCRM.Service.Services.HomeworkFiles;

public class HomeworkFilesService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    HomeworkFileCreateModelValidator createModelValidator,
    HomeworkFileUpdateModelValidator updateModelValidator) : IHomeworkFilesService
{
    public async ValueTask<HomeworkFileViewModel> CreateAsync(HomeworkFileCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);
        var homeworkFile = await unitOfWork.HomeworkFiles.SelectAsync(hf =>
        hf.AssetId == createModel.AssetId
        && hf.HomeworkId == createModel.HomeworkId);

        if (homeworkFile == null)
            throw new NotFoundException("Something is wrong! Try enter correctly ID");

        await unitOfWork.HomeworkFiles.InsertAsync(mapper.Map<HomeworkFile>(createModel));
        await unitOfWork.SaveAsync();

        return await Task.FromResult(mapper.Map<HomeworkFileViewModel>(createModel));
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var homeworkFile = await unitOfWork.HomeworkFiles.SelectAsync(hf => hf.Id == id && !hf.IsDeleted);
        if (homeworkFile == null)
            throw new NotFoundException($"Homework file with ID={id} is not FOUND");

        await unitOfWork.HomeworkFiles.DeleteAsync(homeworkFile);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<HomeworkFileViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null
    {
        var homeworkFiles = unitOfWork.HomeworkFiles.SelectAsQueryable(
            expression: hf => !hf.IsDeleted,
            includes: ["Homework", "Asset"],
            isTracked: false).OrderBy(filter);

        return mapper.Map<IEnumerable<HomeworkFileViewModel>>(homeworkFiles.ToPaginateAsQueryable(@params).ToListAsync());
    }

    public async ValueTask<HomeworkFileViewModel> GetByIdAsync(long id)
    {
        var homeworkFile = await unitOfWork.HomeworkFiles.SelectAsync(hf => hf.Id == id && !hf.IsDeleted) 
            ?? throw new NotFoundException($"Homework file with ID={id} is not FOUND");
        return mapper.Map<HomeworkFileViewModel>(homeworkFile);
    }

    public async ValueTask<HomeworkFileViewModel> UpdateAsync(long id, HomeworkFileUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);
        var homeworkFile = await unitOfWork.HomeworkFiles.SelectAsync(hf => hf.Id == id && !hf.IsDeleted) 
            ?? throw new NotFoundException($"Homework file with ID={id} is not FOUND");
        await unitOfWork.HomeworkFiles.UpdateAsync(homeworkFile);
        await unitOfWork.SaveAsync();

        return mapper.Map<HomeworkFileViewModel>(homeworkFile);
    }
}
