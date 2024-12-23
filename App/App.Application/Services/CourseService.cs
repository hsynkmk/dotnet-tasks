using App.Application.DTOs;
using App.Application.Interfaces;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Services;

internal class CourseService(IUnitOfWork unitOfWork, IMapper mapper) : ICourseService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CourseDto>> GetAllAsync()
    {
        var courses = await _unitOfWork.Courses.GetAllAsync();
        return _mapper.Map<IEnumerable<CourseDto>>(courses);
    }

    public async Task<CourseDto?> GetByIdAsync(int id)
    {
        var course = await _unitOfWork.Courses.GetAsync(c => c.Id == id);
        return _mapper.Map<CourseDto?>(course);
    }

    public async Task CreateAsync(CourseDto courseDto)
    {
        var course = _mapper.Map<Course>(courseDto);
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

    public async Task UpdateAsync(CourseDto courseDto)
    {
        var course = _mapper.Map<Course>(courseDto);
        _unitOfWork.Courses.Update(course);
        await _unitOfWork.SaveAsync();
    }
}
