using App.Domain.Entities;

namespace App.Application.Interfaces;

public interface ICourseService
{
    IEnumerable<Course> GetAll();
    Course GetById(int id);
    void Create(Course book);
    void Update(Course book);
    bool Delete(int id);
}
