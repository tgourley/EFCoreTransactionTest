using EFCoreTransactionTest.Models;

namespace EFCoreTransactionTest.Interfaces;

public interface ICourseService
{
    IEnumerable<Course> GetAllCourses();
    Course GetCourseById(int courseId);
    Course CreateCourse(Course course);
    void AddStudentToCourse(int courseId, int studentId);
    void AddStudentToCourseAtomic(int courseId, int studentId);
    void RemoveStudentFromCourse(int courseId, int studentId);
}
