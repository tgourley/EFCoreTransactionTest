﻿namespace EFCoreTransactionTest.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CurrentCourseCount { get; set; }
    public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
}
