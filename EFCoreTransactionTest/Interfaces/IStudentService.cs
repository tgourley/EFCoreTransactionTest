using EFCoreTransactionTest.Models;

namespace EFCoreTransactionTest.Interfaces;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudents();
    Student GetStudentById(int studentId);
    Student CreateStudent(Student student);
    public void UpdateStudentCourseCount(int studentId, int courseCount);
}
