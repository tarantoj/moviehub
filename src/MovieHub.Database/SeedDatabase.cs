using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieHub.Database;

public class CinemaEntityTypeConfiguration : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.HasData(
            new Cinema { Name = "Cinemarvel", Location = "72 Bette McNee Street, Sandy Gully, NSW 2729" },
            new Cinema { Name = "Moviemania", Location = "7 Old Tenterfield Road, Old Bonalbo, NSW 2469" },
            new Cinema { Name = "BigScreen Bliss", Location = "93 Creek Street, Kooralgin, Queensland 4402" },
            new Cinema { Name = "CineNova", Location = "59 McLachlan Street, Nurcoung, Victoria 3401" },
            new Cinema { Name = "Cinema Royale", Location = "89 Nerrigundah Drive, Junction Village, Victoria 3977" },
            new Cinema { Name = "Flicker Factory", Location = "96 Sale-Heyfield Road, Kardella, Victoria 3951" },
            new Cinema { Name = "CineSpectra", Location = "28 Reynolds Road, Lake Borumba, Queensland 4570" });
    }
}


public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasData(
            new Movie
            {
                Title = "Star Wars: The Phantom Menace (Episode I)",
                ReleaseDate = DateOnly.FromDateTime(new DateTime(1999, 5, 19)),
                Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
                Runtime = 8160,
                Synopsis = "Experience the heroic action and unforgettable adventures of Star Wars: Episode I - The Phantom Menace. See the first fateful steps in the journey of Anakin Skywalker. Stranded on the desert planet Tatooine after rescuing young Queen Amidala from the impending invasion of Naboo, Jedi apprentice Obi-Wan Kenobi and his Jedi Master Qui-Gon Jinn discover nine-year-old Anakin, who is unusually strong in the Force. Anakin wins a thrilling Podrace and with it his freedom as he leaves his home to be trained as a Jedi. The heroes return to Naboo where Anakin and the Queen face massive invasion forces while the two Jedi contend with a deadly foe named Darth Maul. Only then do they realize the invasion is merely the first step in a sinister scheme by the re-emergent forces of darkness known as the Sith.",
                Director = "George Lucas",
                Rating = "PG",
                PrincessTheatreMovieId = "0120915"
            }
            );
    }
}
