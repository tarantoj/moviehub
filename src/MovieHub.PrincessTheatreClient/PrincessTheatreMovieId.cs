using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace MovieHub.PrincessTheatreClient;

[JsonConverter(typeof(PrincessTheatreMovieIdConverter))]
public readonly struct PrincessTheatreMovieId
{
    public FilmProvider FilmProvider { get; }
    public string Id { get; }

    public PrincessTheatreMovieId(string princessTheatreMovieId)
    {
        var pattern = @"(?<FilmProvider>[a-z]{2})(?<Id>\d+)";

        var match = Regex.Match(princessTheatreMovieId, pattern);

        FilmProvider = FilmProviderFromString(match.Groups["FilmProvider"].Value);
        Id = match.Groups["Id"].Value;
    }

    public override string ToString() => $"{FilmProviderToString(FilmProvider)}{Id}";

    private static string FilmProviderToString(FilmProvider filmProvider) =>
        filmProvider switch
        {
            FilmProvider.FilmWorld => "fw",
            FilmProvider.CinemaWorld => "cw",
            _
                => throw new InvalidEnumArgumentException(
                    nameof(filmProvider),
                    (int)filmProvider,
                    typeof(FilmProvider)
                )
        };

    private static FilmProvider FilmProviderFromString(string filmProvider) =>
        filmProvider switch
        {
            "fw" => FilmProvider.FilmWorld,
            "cw" => FilmProvider.CinemaWorld,
            _
                => throw new ArgumentOutOfRangeException(
                    nameof(filmProvider),
                    filmProvider,
                    "Invalid film Provider id prefix"
                )
        };
}
