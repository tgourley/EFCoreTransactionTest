﻿namespace EFCoreTransactionTest.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxStudentCount { get; set; }
    public int CurrentStudentCount { get; set; }
    public virtual ICollection<Student>? Students { get; set; } = new List<Student>();
}
