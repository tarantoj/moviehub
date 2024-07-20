namespace MovieHub.PrincessTheatreClient;

public interface IPrincessTheatreService
{
    Task<MovieResponse?> GetMovieResponse(FilmProvider filmProvider);
}
