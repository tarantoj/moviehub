namespace MovieHub.Api.Models;
public record MovieDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required DateOnly ReleaseDate { get; init; }
    public required string Genre { get; init; }
    public required int Runtime { get; init; }
    public decimal? AverageReviewScore { get; init; }
}
