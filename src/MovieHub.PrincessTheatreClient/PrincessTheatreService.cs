using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace MovieHub.PrincessTheatreClient;

public interface IPrincessTheatreService
{
    Task<MovieResponse?> GetMovieResponse(FilmProvider filmProvider);
}

public class PrincessTheatreService : IPrincessTheatreService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions jsonSerializerOptions =
        new() { PropertyNameCaseInsensitive = true };

    public PrincessTheatreService(HttpClient httpClient, IOptions<PrincessTheatreClientOptions> options)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = options.Value.BaseAddress;
        _httpClient.DefaultRequestHeaders.Add("x-api-key", options.Value.ApiKey);
    }

    public Task<MovieResponse?> GetMovieResponse(FilmProvider filmProvider) =>
        _httpClient.GetFromJsonAsync<MovieResponse>(
            $"/api/v2/{filmProvider.ToString().ToLowerInvariant()}/movies",
            jsonSerializerOptions
        );
}
