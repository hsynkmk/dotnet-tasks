using App.Application.Interfaces;
using App.Domain.Entities;

namespace App.Application.Services;

internal class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _unitOfWork.Courses.GetAllAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Courses.GetAsync(c => c.Id == id);
    }

    public async Task CreateAsync(Course course)
    {
        await _unitOfWork.Courses.AddAsync(course);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await _unitOfWork.Courses.GetAsync(c => c.Id == id);
        if (course == null) return false;

        _unitOfWork.Courses.Remove(course);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task UpdateAsync(Course course)
    {
        _unitOfWork.Courses.Update(course);
        await _unitOfWork.SaveAsync();
    }
}
