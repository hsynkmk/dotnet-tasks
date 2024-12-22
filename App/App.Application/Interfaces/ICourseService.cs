using App.Domain.Entities;

namespace App.Application.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id);
    Task CreateAsync(Course course);
    Task UpdateAsync(Course course);
    Task<bool> DeleteAsync(int id);
}
