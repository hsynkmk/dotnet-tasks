using App.Application.Interfaces;
using App.Domain.Entities;
using App.Infrastructure.Persistence;

namespace App.Infrastructure.Repositories;
internal class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    private readonly AppDbContext _context;
    public CourseRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
