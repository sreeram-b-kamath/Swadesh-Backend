using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;
using Shared.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
{
    public ApplicationDBContext CreateDbContext(string[] args)
    {
        // Load environment variables from the .env file
        DotNetEnv.Env.Load();

        // Retrieve the connection string from the environment variables
        string connectionString = Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING");

        // Create the DbContextOptionsBuilder and configure it to use the connection string
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
        optionsBuilder.UseNpgsql(connectionString);

        // Return a new instance of ApplicationDbContext
        return new ApplicationDBContext(optionsBuilder.Options);
    }
}
