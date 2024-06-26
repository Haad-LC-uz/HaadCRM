﻿using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.ExamDTOs.ExamGrades;

namespace HaadCRM.Service.Services.ExamGrades;

public interface IExamGradeService
{
    ValueTask<ExamGradeViewModel> CreateAsync(ExamGradeCreateModel createModel);
    ValueTask<ExamGradeViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<ExamGradeViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<ExamGradeViewModel> UpdateAsync(long id, ExamGradeUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
}