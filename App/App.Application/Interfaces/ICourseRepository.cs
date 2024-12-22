using App.Domain.Entities;

namespace App.Application.Interfaces;

public interface ICourseRepository : IBaseRepository<Course>
{
    void Update(Course entity);
    void Save();
}
