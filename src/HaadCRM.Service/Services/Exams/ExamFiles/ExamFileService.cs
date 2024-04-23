using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Exams.ExamFiles;

public class ExamFileService(IUnitOfWork unitOfWork, IMapper mapper) : IExamFileService
{
    public async ValueTask<ExamFileViewModel> CreateAsync(ExamFileCreateModel createModel)
    {
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

    public async ValueTask<IEnumerable<ExamFileViewModel>> GetAllAsync()
    {
        var examFiles = await unitOfWork.ExamFiles.SelectAsEnumerableAsync(
            expression: examFile => !examFile.IsDeleted,
            includes: ["Exam", "Asset"]);

        return mapper.Map<IEnumerable<ExamFileViewModel>>(examFiles);
    }

    public async ValueTask<ExamFileViewModel> UpdateAsync(long id, ExamFileUpdateModel updateModel)
    {
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