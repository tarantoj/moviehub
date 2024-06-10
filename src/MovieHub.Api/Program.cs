using Microsoft.EntityFrameworkCore;
using MovieHub.Database;
using MovieHub.PrincessTheatreClient;
using NeoSmart.Caching.Sqlite.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqliteCache("./cache.sqlite");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieHubContext>(options => options.UseSqlite("Data Source=MovieHub.sqlite"));

builder.Services.AddPrincessTheatreClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
