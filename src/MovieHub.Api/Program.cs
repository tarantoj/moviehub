using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieHub.Database;
using MovieHub.PrincessTheatreClient;
using NeoSmart.Caching.Sqlite.AspNetCore;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSqliteCache(
            builder.Configuration.GetConnectionString("Cache") ?? "./cache.sqlite"
        );
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
        });
        builder.Services.AddDbContext<MovieHubContext>(options =>
        {
            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }

            options.UseSqlite(builder.Configuration.GetConnectionString("MovieHubDatabase"));
        });

        if (builder.Environment.IsDevelopment())
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddPrincessTheatreClient();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
