using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Employees.EmployeeRoles;
using HaadCRM.Service.Validators.Exams.ExamFiles;
using Microsoft.EntityFrameworkCore;

namespace HaadCRM.Service.Services.ExamFiles;

public class ExamFileService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    ExamFileCreateModelValidator createModelValidator,
    ExamFileUpdateModelValidator updateModelValidator) : IExamFileService
{
    public async ValueTask<ExamFileViewModel> CreateAsync(ExamFileCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);
        var existExamFile = await unitOfWork.ExamFiles.SelectAsync(ef =>
            ef.ExamId == createModel.ExamId && ef.AssetId == createModel.AssetId);

        if (existExamFile is not null)
            throw new AlreadyExistException($"Exam file with this asset already exists");

        var examFile = mapper.Map<ExamFile>(createModel);

        await unitOfWork.ExamFiles.InsertAsync(examFile);
        await unitOfWork.SaveAsync();

        return mapper.Map<ExamFileViewModel>(examFile);
    }

    public async ValueTask<ExamFileViewModel> GetByIdAsync(long id)
    {
        var examFile = await unitOfWork.ExamFiles.SelectAsync(ef => ef.Id == id)
                       ?? throw new NotFoundException($"ExamFile with ID={id} is not found");

        return mapper.Map<ExamFileViewModel>(examFile);
    }

    public async ValueTask<IEnumerable<ExamFileViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var examFiles = unitOfWork.ExamFiles.SelectAsQueryable(
            expression: examFile => !examFile.IsDeleted,
            includes: ["Exam", "Asset"],
            isTracked: false).OrderBy(filter);

        return mapper.Map<IEnumerable<ExamFileViewModel>>(examFiles.ToPaginateAsQueryable(@params).ToListAsync());
    }

    public async ValueTask<ExamFileViewModel> UpdateAsync(long id, ExamFileUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);
        var existExamFile = await unitOfWork.ExamFiles.SelectAsync(ef => ef.Id == id)
                       ?? throw new NotFoundException($"ExamFile with ID={id} is not found");

        var examFile = mapper.Map<ExamFile>(existExamFile);

        await unitOfWork.ExamFiles.UpdateAsync(examFile);
        await unitOfWork.SaveAsync();

        return mapper.Map<ExamFileViewModel>(examFile);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var examFile = await unitOfWork.ExamFiles.SelectAsync(ef => ef.Id == id)
                       ?? throw new NotFoundException($"ExamFile with ID={id} is not found");

        await unitOfWork.ExamFiles.DeleteAsync(examFile);
        await unitOfWork.SaveAsync();

        return true;
    }
}