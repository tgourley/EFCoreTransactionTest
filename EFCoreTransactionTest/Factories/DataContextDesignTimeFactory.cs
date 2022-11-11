using EFCoreTransactionTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreTransactionTest.Factories;

public class DataContextDesignTimeFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnectionString"));
        return new DataContext(optionsBuilder.Options);
    }
}
