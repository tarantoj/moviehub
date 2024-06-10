namespace MovieHub.Api.Models;

public record ReviewDto
{
    public int? Id { get; init; }
    public int MovieId { get; init; }
    public required decimal Score { get; init; }
    public required string Comment { get; init; }
    public required DateTimeOffset ReviewDate { get; init; }
}
