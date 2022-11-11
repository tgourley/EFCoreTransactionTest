using EFCoreTransactionTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTransactionTest.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
}
