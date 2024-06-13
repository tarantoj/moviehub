namespace MovieHub.Api.Models;

public record ShowingsDto
{
    public required string CinemaName { get; init; }
    public required decimal TicketPrice { get; init; }
    public required DateOnly Showtime { get; init; }
}

public record MovieDetailsDto
{
    public required string Title { get; init; }
    public required DateOnly ReleaseDate { get; init; }
    public required string Genre { get; init; }
    public required TimeSpan Runtime { get; init; }
    public required string Synopsis { get; init; }
    public required string Director { get; init; }
    public required string Rating { get; init; }
    public decimal FilmWorldPrice { get; init; }
    public decimal CinemaWorldPrice { get; init; }

    public IEnumerable<ShowingsDto> Showings { get; init; } = Enumerable.Empty<ShowingsDto>();
}
