using App.Domain.Entities;

namespace App.Application.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAll();
    Course GetById(int id);
    void Create(Course course);
    void Update(Course course);
    bool Delete(int id);
}
