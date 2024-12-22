using App.Application.Interfaces;
using App.Domain.Entities;

namespace App.Application.Services;

internal class CourseService(IUnitOfWork unitOfWork) : ICourseService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Course>> GetAll()
    {
        return await _unitOfWork.Courses.GetAll();
    }

    public Course GetById(int id)
    {
        return _unitOfWork.Courses.Get(u => u.Id == id);
    }

    public void Create(Course course)
    {
        _unitOfWork.Courses.Add(course);
        _unitOfWork.Courses.Save();
    }

    public bool Delete(int id)
    {
        try
        {
            Course? courseFromDb = _unitOfWork.Courses.Get(u => u.Id == id);

            if (courseFromDb != null)
            {
                _unitOfWork.Courses.Remove(courseFromDb);
                _unitOfWork.Courses.Save();
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Update(Course course)
    {
        _unitOfWork.Courses.Update(course);
        _unitOfWork.Courses.Save();
    }
}
