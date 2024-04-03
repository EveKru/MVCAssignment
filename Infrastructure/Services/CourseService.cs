using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CourseService(CourseRepository courseRepository)
{
    private readonly CourseRepository _courseRepository = courseRepository;


}
