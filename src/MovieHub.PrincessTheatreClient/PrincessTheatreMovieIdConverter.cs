using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieHub.PrincessTheatreClient;

public class PrincessTheatreMovieIdConverter : JsonConverter<PrincessTheatreMovieId>
{
    public override PrincessTheatreMovieId Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options) => new(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, PrincessTheatreMovieId value,
        JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
}