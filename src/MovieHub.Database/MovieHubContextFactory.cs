using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MovieHub.Database;

public class MovieHubContextFactory : IDesignTimeDbContextFactory<MovieHubContext>
{
    public MovieHubContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MovieHubContext>();
        optionsBuilder.UseSqlite("Data Source=MovieHub.sqlite");

        return new MovieHubContext(optionsBuilder.Options);
    }
}