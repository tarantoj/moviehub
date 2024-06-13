namespace MovieHub.PrincessTheatreClient;

public record MovieResponse
{
    public required string Provider { get; set; }
    public required IEnumerable<Movie> Movies { get; set; }
}