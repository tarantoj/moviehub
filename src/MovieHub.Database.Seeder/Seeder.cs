namespace MovieHub.Database.Seeder;

public static class Seeder
{
    private static readonly IEnumerable<Cinema> Cinemas =
    [
        new() { Name = "Cinemarvel", Location = "72 Bette McNee Street, Sandy Gully, NSW 2729" },
        new() { Name = "Moviemania", Location = "7 Old Tenterfield Road, Old Bonalbo, NSW 2469" },
        new()
        {
            Name = "BigScreen Bliss",
            Location = "93 Creek Street, Kooralgin, Queensland 4402"
        },
        new() { Name = "CineNova", Location = "59 McLachlan Street, Nurcoung, Victoria 3401" },
        new()
        {
            Name = "Cinema Royale",
            Location = "89 Nerrigundah Drive, Junction Village, Victoria 3977"
        },
        new()
        {
            Name = "Flicker Factory",
            Location = "96 Sale-Heyfield Road, Kardella, Victoria 3951"
        },
        new() { Name = "CineSpectra", Location = "28 Reynolds Road, Lake Borumba, Queensland 4570" }
    ];

    private static readonly IEnumerable<Movie> Movies =
    [
        new()
        {
            Title = "Star Wars: The Phantom Menace (Episode I)",
            ReleaseDate = new DateOnly(1999, 5, 19),
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
            ReleaseDate = new DateOnly(2002, 5, 16),
            Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
            Runtime = TimeSpan.FromSeconds(8520),
            Synopsis =
                "Watch the seeds of Anakin Skywalker's transformation take root in Star Wars: Episode II - Attack of the Clones. Ten years after the invasion of Naboo, the galaxy is on the brink of civil war. Under the leadership of a renegade Jedi named Count Dooku, thousands of solar systems threaten to break away from the Galactic Republic. When an assassination attempt is made on Senator Padmé Amidala, the former Queen of Naboo, twenty-year-old Jedi apprentice Anakin Skywalker is assigned to protect her. In the course of his mission, Anakin discovers his love for Padmé as well as his own darker side. Soon, Anakin, Padmé, and Obi-Wan Kenobi are drawn into the heart of the Separatist movement and the beginning of the Clone Wars.",
            Director = "George Lucas",
            Rating = "PG-13",
            PrincessTheatreMovieId = "0121765"
        },
        new()
        {
            Title = "Star Wars: Revenge of the Sith (Episode III)",
            ReleaseDate = new DateOnly(2005, 05, 19),
            Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
            Runtime = TimeSpan.FromSeconds(8399),
            Synopsis =
                "Discover the true power of the dark side in Star Wars: Episode III - Revenge of the Sith. Years after the onset of the Clone Wars, the noble Jedi Knights lead a massive clone army into a galaxy-wide battle against the Separatists. When the sinister Sith unveil a thousand-year-old plot to rule the galaxy, the Republic crumbles and from its ashes rises the evil Galactic Empire. Jedi hero Anakin Skywalker is seduced by the dark side of the Force to become the Emperor's new apprentice – Darth Vader. The Jedi are decimated, as Obi-Wan Kenobi and Jedi Master Yoda are forced into hiding.",
            Director = "George Lucas",
            Rating = "PG-13",
            PrincessTheatreMovieId = "0121766"
        },
        new()
        {
            Title = "Star Wars: A New Hope (Episode IV)",
            ReleaseDate = new DateOnly(1977, 10, 27),
            Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
            Runtime = TimeSpan.FromSeconds(6300),
            Synopsis =
                "Luke Skywalker begins a journey that will change the galaxy in Star Wars: Episode IV - A New Hope. Nineteen years after the formation of the Empire, Luke is thrust into the struggle of the Rebel Alliance when he meets Obi-Wan Kenobi, who has lived for years in seclusion on the desert planet of Tatooine. Obi-Wan begins Luke's Jedi training as Luke joins him on a daring mission to rescue the beautiful Rebel leader Princess Leia from the clutches of Darth Vader and the evil Empire.",
            Director = "George Lucas",
            Rating = "PG",
            PrincessTheatreMovieId = "0076759"
        },
        new()
        {
            Title = "Star Wars: The Empire Strikes Back (Episode V)",
            ReleaseDate = new DateOnly(1980, 08, 07),
            Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
            Runtime = TimeSpan.FromSeconds(7440),
            Synopsis =
                "After the destruction of the Death Star, Imperial forces continue to pursue the Rebels. After the Rebellion's defeat on the ice planet Hoth, Luke journeys to the planet Dagobah to train with Jedi Master Yoda, who has lived in hiding since the fall of the Republic. In an attempt to convert Luke to the dark side, Darth Vader lures young Skywalker into a trap in the Cloud City of Bespin.",
            Director = "George Lucas",
            Rating = "PG",
            PrincessTheatreMovieId = "0080684"
        },
        new()
        {
            Title = "Star Wars: Return of the Jedi (Episode VI)",
            ReleaseDate = new DateOnly(1983, 10, 27),
            Genre = "Action, Adventure, Fantasy, Live Action, Science Fiction",
            Runtime = TimeSpan.FromSeconds(7859),
            Synopsis =
                "After a quick trip back to Tatooine, Luke Skywalker, Leia Organa, and Han Solo are reunited and join up with the amassing rebel fleet to take down the evil Empire once and for all. But the Empire is plotting too. Emperor Palpatine commands his troops aboard his newly constructed Death Star stationed above the forest moon of Endor, where the rebels - and some unlikely furry friends - make their stand against the Empire. While Luke Skywalker confronts Darth Vader on the Death Star once more, Han leads a team to take out a shield protecting the battle station so that the rebel fleet can destroy it once more and finally put an end to the war.",
            Director = "George Lucas",
            Rating = "PG",
            PrincessTheatreMovieId = "0086190"
        },
        new()
        {
            Title = "Star Wars: The Force Awakens (Episode VII)",
            ReleaseDate = new DateOnly(2015, 12, 18),
            Genre = "Action - Adventure, Science Fiction",
            Runtime = TimeSpan.FromSeconds(8160),
            Synopsis =
                "Thirty years since the destruction of the second Death Star, the sinister First Order, commanded by the mysterious Snoke and apprentice Kylo Ren, rise from the ashes of the Empire. The Resistance, led by General Leia Organa, attempts to thwart the First Order's threat, but they're desperate for help. Rey, a desert scavenger, and Finn, an ex-stormtrooper, find themselves joining forces with Han Solo and Chewbacca in a desperate mission to return a BB-unit droid with a map to Luke Skywalker back to the Resistance.",
            Director = "George Lucas",
            Rating = "PG-13",
            PrincessTheatreMovieId = "2488496"
        },
        new()
        {
            Title = "Star Wars: The Last Jedi (Episode VIII)",
            ReleaseDate = new DateOnly(2017, 12, 13),
            Genre = "Action - Adventure, Science Fiction",
            Runtime = TimeSpan.FromSeconds(9000),
            Synopsis =
                "The Resistance is in desperate need of help when they find themselves impossibly pursued by the First Order. While Rey travels to a remote planet called Ahch-To to recruit Luke Skywalker to the Resistance, Finn and Rose, a mechanic, go on their own mission in the hopes of helping the Resistance finally escape the First Order. But everyone finds themselves on the salt-planet of Crait for a last stand.",
            Director = "George Lucas",
            Rating = "PG-13",
            PrincessTheatreMovieId = "2527336"
        },
        new()
        {
            Title = "Star Wars: The Rise of Skywalker (Episode IX)",
            ReleaseDate = new DateOnly(2019, 12, 18),
            Genre = "Action - Adventure, Science Fiction",
            Runtime = TimeSpan.FromSeconds(7992),
            Synopsis =
                "Lucasfilm and director J.J. Abrams join forces once  more to take viewers on an epic journey to a galaxy far, far away with Star Wars: The Rise of Skywalker, the riveting conclusion of the  landmark Skywalker saga, in which new legends will be born and the final battle for freedom is yet to come.",
            Director = "George Lucas",
            Rating = "PG-13",
            PrincessTheatreMovieId = "2527338"
        }
    ];

    public static readonly IEnumerable<Showing> Showings =
    [
        new()
        {
            Movie = Movies.First(m => m.Title == "Star Wars: The Phantom Menace (Episode I)"),
            Cinema = Cinemas.First(c => c.Name == "Cinemarvel"),
            TicketPrice = 24.5m,
            Showtime = new DateOnly(2024, 12, 31)
        }
    ];
}
