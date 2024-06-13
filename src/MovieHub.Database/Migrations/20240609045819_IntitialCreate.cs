using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieHub.Database.Migrations
{
    /// <inheritdoc />
    public partial class IntitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Runtime = table.Column<int>(type: "INTEGER", nullable: false),
                    Synopsis = table.Column<string>(type: "TEXT", nullable: false),
                    Director = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Rating = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    PrincessTheatreMovieId = table.Column<string>(
                        type: "TEXT",
                        maxLength: 16,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Showings",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Showtime = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TicketPrice = table.Column<decimal>(
                        type: "TEXT",
                        precision: 4,
                        scale: 2,
                        nullable: false
                    ),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    CinemaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Showings_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Showings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Showings_CinemaId", table: "Showings", column: "CinemaId");

            migrationBuilder.CreateIndex(name: "IX_Showings_MovieId", table: "Showings", column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Showings");

            migrationBuilder.DropTable(name: "Cinemas");

            migrationBuilder.DropTable(name: "Movies");
        }
    }
}
