using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MovieHub.Database;

public class MovieHubContext(DbContextOptions<MovieHubContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; init; }
    public DbSet<Cinema> Cinemas { get; init; }
    public DbSet<Showing> Showings { get; init; }
    public DbSet<Review> Reviews { get; set; }
}

/*[EntityTypeConfiguration(typeof(MovieEntityTypeConfiguration))]*/
public class Movie
{
    public int Id { get; init; }

    [MaxLength(128)]
    public string Title { get; init; }

    public DateOnly ReleaseDate { get; init; }

    [MaxLength(64)]
    public string Genre { get; init; }

    public TimeSpan Runtime { get; init; }
    public string Synopsis { get; init; }

    [MaxLength(64)]
    public string Director { get; init; }

    [MaxLength(8)]
    public string Rating { get; init; }

    [MaxLength(16)]
    public string PrincessTheatreMovieId { get; init; }

    public ICollection<Showing> Showings { get; init; }
    public ICollection<Review> Reviews { get; init; }
}

public class Showing
{
    public int Id { get; init; }
    public DateOnly Showtime { get; init; }

    [Precision(4, 2)]
    public decimal TicketPrice { get; init; }

    public Movie Movie { get; set; } = null!;
    public Cinema Cinema { get; set; } = null!;
}

/*[EntityTypeConfiguration(typeof(CinemaEntityTypeConfiguration))]*/
public class Cinema
{
    public int Id { get; init; }

    [MaxLength(64)]
    public required string Name { get; init; }

    public required string Location { get; init; }

    public ICollection<Showing> Showings { get; init; }
}

public class Review
{
    public int Id { get; init; }

    [Precision(4, 2)]
    public decimal Score { get; init; }

    public string Comment { get; init; }
    public DateTimeOffset ReviewDate { get; set; }
    public int MovieId { get; set; }

    public Movie Movie { get; init; } = null!;
}
