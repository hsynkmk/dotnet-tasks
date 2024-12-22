namespace App.Application.Interfaces;

public interface IUnitOfWork
{
    ICourseRepository Courses { get; }
}
