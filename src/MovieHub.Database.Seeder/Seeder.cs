namespace MovieHub.Database.Seeder;

public class Seeder
{
    private static readonly IEnumerable<Cinema> Cinemas = new Cinema[]
    {
        new() { Name = "Cinemarvel", Location = "72 Bette McNee Street, Sandy Gully, NSW 2729" },
        new() { Name = "Moviemania", Location = "7 Old Tenterfield Road, Old Bonalbo, NSW 2469" },
        new() { Name = "BigScreen Bliss", Location = "93 Creek Street, Kooralgin, Queensland 4402" },
        new() { Name = "CineNova", Location = "59 McLachlan Street, Nurcoung, Victoria 3401" },
        new() { Name = "Cinema Royale", Location = "89 Nerrigundah Drive, Junction Village, Victoria 3977" },
        new() { Name = "Flicker Factory", Location = "96 Sale-Heyfield Road, Kardella, Victoria 3951" },
        new() { Name = "CineSpectra", Location = "28 Reynolds Road, Lake Borumba, Queensland 4570" }
    };

    private static readonly IEnumerable<Movie> Movies = new Movie[]
    {
        new()
        {
            Title = "Star Wars: The Phantom Menace (Episode I)",
            ReleaseDate = DateOnly.FromDateTime(new DateTime(1999, 5, 19)),
            Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
            Runtime = TimeSpan.FromMinutes(136),
            Synopsis =
                "Experience the heroic action and unforgettable adventures of Star Wars: Episode I - The Phantom Menace. See the first fateful steps in the journey of Anakin Skywalker. Stranded on the desert planet Tatooine after rescuing young Queen Amidala from the impending invasion of Naboo, Jedi apprentice Obi-Wan Kenobi and his Jedi Master Qui-Gon Jinn discover nine-year-old Anakin, who is unusually strong in the Force. Anakin wins a thrilling Podrace and with it his freedom as he leaves his home to be trained as a Jedi. The heroes return to Naboo where Anakin and the Queen face massive invasion forces while the two Jedi contend with a deadly foe named Darth Maul. Only then do they realize the invasion is merely the first step in a sinister scheme by the re-emergent forces of darkness known as the Sith.",
            Director = "George Lucas",
            Rating = "PG",
            PrincessTheatreMovieId = "0120915"
        },
        new()
        {
            Title = "Star Wars: Attack of the Clones (Episode II)",
            ReleaseDate = DateOnly.FromDateTime(new DateTime(2002, 5, 16)),
            Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
            Runtime = TimeSpan.FromSeconds(8520),
            Synopsis =
                "Watch the seeds of Anakin Skywalker's transformation take root in Star Wars: Episode II - Attack of the Clones. Ten years after the invasion of Naboo, the galaxy is on the brink of civil war. Under the leadership of a renegade Jedi named Count Dooku, thousands of solar systems threaten to break away from the Galactic Republic. When an assassination attempt is made on Senator Padmé Amidala, the former Queen of Naboo, twenty-year-old Jedi apprentice Anakin Skywalker is assigned to protect her. In the course of his mission, Anakin discovers his love for Padmé as well as his own darker side. Soon, Anakin, Padmé, and Obi-Wan Kenobi are drawn into the heart of the Separatist movement and the beginning of the Clone Wars.",
            Director = "George Lucas",
            Rating = "PG-13",
            PrincessTheatreMovieId = "0121765"
        }
    };

    private static readonly IEnumerable<Showing> Showings = new Showing[]
    {
        new()
        {
            Movie = Movies.First(m => m.Title == "Star Wars: The Phantom Menace (Episode I)"),
            Cinema = Cinemas.First(c => c.Name == "Cinemarvel"), TicketPrice = 24.5m,
            Showtime = DateOnly.FromDateTime(new DateTime(2024, 12, 31))
        }
    };
}