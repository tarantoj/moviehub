namespace MovieHub.PrincessTheatreClient;

public record Movie
{
    public required PrincessTheatreMovieId Id { get; set; }
    public required string Title { get; set; }
    public required string Type { get; set; }
    public required Uri Poster { get; set; }
    public required string Actors { get; set; }
    public required decimal Price { get; set; }
}