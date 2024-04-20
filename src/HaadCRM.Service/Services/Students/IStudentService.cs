﻿using HaadCRM.Service.DTOs.StudentDTOs.Students;

namespace HaadCRM.Service.Services.Students;

public interface IStudentService
{
    ValueTask<StudentViewModel> CreateAsync(StudentCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<StudentViewModel>> GetAllAsync();
    ValueTask<StudentViewModel> GetByIdAsync(long id);
    ValueTask<StudentViewModel> UpdateAsync(long id, StudentUpdateModel updateModel);
}