using EFCoreTransactionTest.Data;
using EFCoreTransactionTest.Interfaces;
using EFCoreTransactionTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTransactionTest.Services;

public class StudentService : IStudentService
{
    private readonly DataContext _dbContext;

    public StudentService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Student CreateStudent(Student student)
    {
        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();
        return student;
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _dbContext.Students.Include("Courses");
    }

    public Student GetStudentById(int studentId)
    {
        return _dbContext.Students.Include("Courses").FirstOrDefault(x => x.Id == studentId);
    }

    public void UpdateStudentCourseCount(int studentId, int courseCount)
    {
        var student = _dbContext.Students.FirstOrDefault(x => x.Id == studentId);

        if (student == null)
            throw new Exception("Student not found.");

        student.CurrentCourseCount = courseCount;
        _dbContext.SaveChanges();
    }
}
