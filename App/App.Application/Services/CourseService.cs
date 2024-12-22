using App.Application.Interfaces;
using App.Domain.Entities;

namespace App.Application.Services;

public class CourseService(IUnitOfWork unitOfWork) : ICourseService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public void Create(Course book)
    {
        _unitOfWork.Courses.Add(book);
        _unitOfWork.Courses.Save();
    }

    public bool Delete(int id)
    {
        try
        {
            Course? bookFromDb = _unitOfWork.Courses.Get(u => u.Id == id);

            if (bookFromDb != null)
            {
                _unitOfWork.Courses.Remove(bookFromDb);
                _unitOfWork.Courses.Save();
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<Course> GetAll()
    {
        return _unitOfWork.Courses.GetAll();
    }

    public Course GetById(int id)
    {
        return _unitOfWork.Courses.Get(u => u.Id == id);
    }

    public void Update(Course book)
    {
        _unitOfWork.Courses.Update(book);
        _unitOfWork.Courses.Save();
    }
}
