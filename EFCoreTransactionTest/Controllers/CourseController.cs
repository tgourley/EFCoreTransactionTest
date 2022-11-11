using EFCoreTransactionTest.Interfaces;
using EFCoreTransactionTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTransactionTest.Controllers;
[Route("api")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("courses")]
    public IEnumerable<Course> GetAllCourses()
    {
        return _courseService.GetAllCourses();
    }

    [HttpGet("courses/{courseId:int}")]
    public Course GetCourseById(int courseId)
    {
        return _courseService.GetCourseById(courseId);
    }

    [HttpPost("courses")]
    public Course CreateCourse(Course course)
    {
        return _courseService.CreateCourse(course);
    }

    [HttpPut("courses/add-student")]
    public void AddStudentToCourse(int courseId, int studentId)
    {
        _courseService.AddStudentToCourse(courseId, studentId);
    }

    [HttpPut("courses/add-student-atomic")]
    public void AddStudentToCourseAtomic(int courseId, int studentId)
    {
        _courseService.AddStudentToCourseAtomic(courseId, studentId);
    }

    [HttpPut("courses/remove-student")]
    public void RemoveStudentFromCourse(int courseId, int studentId)
    {
        _courseService.RemoveStudentFromCourse(courseId, studentId);
    }
}
