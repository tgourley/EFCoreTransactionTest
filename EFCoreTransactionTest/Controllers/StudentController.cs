using EFCoreTransactionTest.Interfaces;
using EFCoreTransactionTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTransactionTest.Controllers;
[Route("api")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    [Route("students")]
    public IEnumerable<Student> GetAll()
    {
        return _studentService.GetAllStudents();
    }

    [HttpGet]
    [Route("students/{studentId:int}")]
    public Student GetById(int studentId)
    {
        return _studentService.GetStudentById(studentId);
    }

    [HttpPost("students")]
    public Student CreateStudent(Student student)
    {
        return _studentService.CreateStudent(student);
    }
}
