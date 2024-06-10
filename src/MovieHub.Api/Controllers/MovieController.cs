using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using MovieHub.Api.Models;
using MovieHub.Database;
using MovieHub.PrincessTheatreClient;

namespace MovieHub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController(
    ILogger<MovieController> logger,
    MovieHubContext movieHubContext,
    IPrincessTheatreService princessTheatreService,
    IDistributedCache cache) : ControllerBase
{
    [HttpGet]
    public ActionResult<IAsyncEnumerable<MovieDto>> Get([FromQuery] string? title, [FromQuery] HashSet<string>? genres = null)
    {
        logger.LogInformation("Getting movies with title matching {Title} and genres matching {@Genres}", title, genres);

        var movies = movieHubContext.Movies.AsNoTracking()
            .Include(x => x.Reviews)
            .Where(x => string.IsNullOrEmpty(title) || x.Title.Contains(title))
            .Where(x => genres == null || genres.Count() == 0 || genres.Any(g => x.Genre.Contains(g)))
            .Select(x => new
            {
                x.Id,
                x.Genre,
                x.ReleaseDate,
                x.Title,
                x.Runtime,
                Reviews = x.Reviews.Select(x => new { x.Score })
            })
            .AsAsyncEnumerable()
            .Select(x => new MovieDto
            {
                Id = x.Id,
                Genre = x.Genre,
                ReleaseDate = x.ReleaseDate,
                Title = x.Title,
                Runtime = x.Runtime,
                AverageReviewScore = x.Reviews.Select(x => x.Score).DefaultIfEmpty().Average()
            });


        return Ok(movies);
    }

    [HttpGet("details")]
    public async Task<ActionResult<IEnumerable<MovieDetailsDto>>> GetMovieDetails()
    {
        var cinemaWorldPrices = await cache.GetOrCreate(
            FilmProvider.CinemaWorld.ToString(),
            async () => (await princessTheatreService.GetMovieResponse(FilmProvider.CinemaWorld))?.Movies ?? []);

        var filmWorldPrices = await cache.GetOrCreate(FilmProvider.FilmWorld.ToString(), async () => (await princessTheatreService.GetMovieResponse(FilmProvider.FilmWorld))?.Movies ?? []);

        var movies = movieHubContext.Movies.AsNoTracking()
          .Include(m => m.Showings)
          .ThenInclude(s => s.Cinema)
          .Select(movie => new
          {
              movie.Title,
              Showings = movie.Showings.Select(s => new ShowingsDto { TicketPrice = s.TicketPrice, Showtime = s.Showtime, CinemaName = s.Cinema.Name }),
              movie.Synopsis,
              movie.Runtime,
              movie.ReleaseDate,
              movie.Director,
              movie.Genre,
              movie.Rating,
              movie.PrincessTheatreMovieId
          }).AsAsyncEnumerable()
          .Select(movie => new MovieDetailsDto
          {
              Title = movie.Title,
              Showings = movie.Showings,
              Synopsis = movie.Synopsis,
              Runtime = movie.Runtime,
              ReleaseDate = movie.ReleaseDate,
              Director = movie.Director,
              Genre = movie.Genre,
              Rating = movie.Rating,
              FilmWorldPrice = filmWorldPrices.Single(p => p.Id.Id == movie.PrincessTheatreMovieId).Price,
              CinemaWorldPrice = cinemaWorldPrices.Single(p => p.Id.Id == movie.PrincessTheatreMovieId).Price
          });

        return Ok(movies);
    }

    [HttpGet("test")]
    public async Task<ActionResult<MovieResponse>> GetTest()
    {
        var prices = await princessTheatreService.GetMovieResponse(FilmProvider.CinemaWorld);
        return Ok(prices);
    }
}
