using EFCoreTransactionTest.Data;
using EFCoreTransactionTest.Interfaces;
using EFCoreTransactionTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTransactionTest.Services;

public class CourseService : ICourseService
{
    private readonly DataContext _dataContext;
    private readonly IStudentService _studentService;

    public CourseService(DataContext dataContext, IStudentService studentService)
    {
        _dataContext = dataContext;
        _studentService = studentService;
    }

    public IEnumerable<Course> GetAllCourses()
    {
        return _dataContext.Courses.Include("Students");
    }

    public Course GetCourseById(int courseId)
    {
        return _dataContext.Courses
            .Include("Students")
            .FirstOrDefault(x => x.Id == courseId);
    }

    public Course CreateCourse(Course course)
    {
        _dataContext.Courses.Add(course);
        _dataContext.SaveChanges();
        return course;
    }

    public void AddStudentToCourse(int courseId, int studentId)
    {
        var student = _studentService.GetStudentById(studentId);
        var course = GetCourseById(courseId);
        course.Students.Add(student);
        _studentService.UpdateStudentCourseCount(studentId, student.CurrentCourseCount + 1);
        throw new Exception("Problem adding student!");
        course.CurrentStudentCount++;
        _dataContext.SaveChanges();
    }

    public void AddStudentToCourseAtomic(int courseId, int studentId)
    {
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            try
            {
                var student = _studentService.GetStudentById(studentId);
                var course = GetCourseById(courseId);
                course.Students.Add(student);
                _studentService.UpdateStudentCourseCount(studentId, student.CurrentCourseCount + 1);
                throw new Exception("Problem adding student!");
                course.CurrentStudentCount++;
                _dataContext.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error occurred.");
            }
        }
    }

    public void RemoveStudentFromCourse(int courseId, int studentId)
    {
        var student = _studentService.GetStudentById(studentId);
        var course = GetCourseById(courseId);
        course.Students.Remove(student);
        course.CurrentStudentCount--;
        _studentService.UpdateStudentCourseCount(studentId, student.CurrentCourseCount - 1);
        _dataContext.SaveChanges();
    }
}
