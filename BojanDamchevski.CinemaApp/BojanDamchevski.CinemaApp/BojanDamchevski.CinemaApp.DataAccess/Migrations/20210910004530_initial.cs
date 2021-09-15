using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BojanDamchevski.CinemaApp.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaMovie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaMovieId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieReservation_CinemaMovie_CinemaMovieId",
                        column: x => x.CinemaMovieId,
                        principalTable: "CinemaMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieReservation_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieReservation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Bitola", "Cinema Bitola" },
                    { 2, "Skopje", "Cinema Skopje" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, @"Director: George Lucas 
                 Cast: Ewan McGRegor, Hayden Christensen, Natalie Portman", 8, "Star Wars: Episode III - Revenge of the Sith" },
                    { 2, @"Director: Gore Verbinski 
                 Cast: Johnny Depp, Keira Knightley, Orlando Bloom", 5, "Pirates of the Caribbean: The Curse of the Black Pearl" },
                    { 3, @"Director: Nick Cassavetes 
                 Cast: Ryan Gosling, Rachel McAdams", 9, "The Notebook" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2021, 9, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Bojan", "Damchevski" },
                    { 2, "Jovana", "Miskimovska" },
                    { 3, "Stefan", "Trajkov" }
                });

            migrationBuilder.InsertData(
                table: "CinemaMovie",
                columns: new[] { "Id", "CinemaId", "MovieId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "CinemaMovie",
                columns: new[] { "Id", "CinemaId", "MovieId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "CinemaMovie",
                columns: new[] { "Id", "CinemaId", "MovieId" },
                values: new object[] { 3, 2, 3 });

            migrationBuilder.InsertData(
                table: "MovieReservation",
                columns: new[] { "Id", "CinemaMovieId", "ReservationId", "UserId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "MovieReservation",
                columns: new[] { "Id", "CinemaMovieId", "ReservationId", "UserId" },
                values: new object[] { 2, 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "MovieReservation",
                columns: new[] { "Id", "CinemaMovieId", "ReservationId", "UserId" },
                values: new object[] { 3, 3, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovie_CinemaId",
                table: "CinemaMovie",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovie_MovieId",
                table: "CinemaMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieReservation_CinemaMovieId",
                table: "MovieReservation",
                column: "CinemaMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieReservation_ReservationId",
                table: "MovieReservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieReservation_UserId",
                table: "MovieReservation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieReservation");

            migrationBuilder.DropTable(
                name: "CinemaMovie");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
