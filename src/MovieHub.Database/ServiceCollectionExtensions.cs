using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MovieHub.Database;

public static class ServiceCollectionExtensions
{
    public static void AddMovieHubDatabase(this IServiceCollection services, Action<SqliteDbContextOptionsBuilder>? sqliteOptionsAction)
    {
        services.AddDbContext<MovieHubContext>(options => options.UseSqlite(sqliteOptionsAction));
    }
}
