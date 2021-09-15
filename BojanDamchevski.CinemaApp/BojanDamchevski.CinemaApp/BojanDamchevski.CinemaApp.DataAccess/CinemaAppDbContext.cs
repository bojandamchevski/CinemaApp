using BojanDamchevski.CinemaApp.Domain.Enums;
using BojanDamchevski.CinemaApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.DataAccess
{
    public class CinemaAppDbContext : DbContext
    {
        public CinemaAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cinema>()
                .HasMany(x => x.CinemaMovies)
                .WithOne(x => x.Cinema)
                .HasForeignKey(x => x.CinemaId);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.CinemaMovies)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Reservation>();

            modelBuilder.Entity<User>()
                .HasMany(x => x.MovieReservation)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Cinema>()
                .HasData(new Cinema
                {
                    Id = 1,
                    Location = "Bitola",
                    Name = "Cinema Bitola",
                },
                new Cinema
                {
                    Id = 2,
                    Location = "Skopje",
                    Name = "Cinema Skopje",
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 1,
                    Title = "Star Wars: Episode III - Revenge of the Sith",
                    Description = "Director: George Lucas \n Cast: Ewan McGRegor, Hayden Christensen, Natalie Portman",
                    Genre = MovieGenreEnum.SciFi
                },
                new Movie
                {
                    Id = 2,
                    Title = "Pirates of the Caribbean: The Curse of the Black Pearl",
                    Description = "Director: Gore Verbinski \n Cast: Johnny Depp, Keira Knightley, Orlando Bloom",
                    Genre = MovieGenreEnum.Adventure
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Notebook",
                    Description = "Director: Nick Cassavetes \n Cast: Ryan Gosling, Rachel McAdams",
                    Genre = MovieGenreEnum.Romance
                });

            modelBuilder.Entity<Reservation>()
                .HasData(new Reservation
                {
                    Id = 1,
                    Date = DateTime.Today.AddDays(10)
                },
                new Reservation
                {
                    Id = 2,
                    Date = DateTime.Today.AddDays(12)
                },
                new Reservation
                {
                    Id = 3,
                    Date = DateTime.Today.AddDays(14)
                });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Bojan",
                    LastName = "Damchevski"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jovana",
                    LastName = "Miskimovska"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Stefan",
                    LastName = "Trajkov"
                });

            modelBuilder.Entity<CinemaMovie>()
                .HasData(new CinemaMovie
                {
                    Id = 1,
                    CinemaId = 1,
                    MovieId = 1
                },
                new CinemaMovie
                {
                    Id = 2,
                    CinemaId = 1,
                    MovieId = 2
                },
                new CinemaMovie
                {
                    Id = 3,
                    CinemaId = 2,
                    MovieId = 3
                });

            modelBuilder.Entity<MovieReservation>()
                .HasData(new MovieReservation
                {
                    Id = 1,
                    CinemaMovieId = 1,
                    ReservationId = 1,
                    UserId = 1
                },
                new MovieReservation
                {
                    Id = 2,
                    CinemaMovieId = 2,
                    ReservationId = 2,
                    UserId = 2
                },
                new MovieReservation
                {
                    Id = 3,
                    CinemaMovieId = 3,
                    ReservationId = 3,
                    UserId = 3
                });
        }
    }
}
