﻿using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;

namespace HaadCRM.Service.Services.Homeworks.HomeworkFiles;

public interface IHomeworkFilesService
{
    ValueTask<HomeworkFileViewModel> CreateAsync(HomeworkFileCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<HomeworkFileViewModel>> GetAllAsync();
    ValueTask<HomeworkFileViewModel> GetByIdAsync(long id);
    ValueTask<HomeworkFileViewModel> UpdateAsync(long id, HomeworkFileUpdateModel updateModel);
}