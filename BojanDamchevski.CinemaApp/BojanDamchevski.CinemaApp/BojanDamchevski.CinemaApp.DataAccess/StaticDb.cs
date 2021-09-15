using BojanDamchevski.CinemaApp.Domain.Enums;
using BojanDamchevski.CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.DataAccess
{
    public static class StaticDb
    {
        public static List<Cinema> CinemasDb = new List<Cinema>()
        {
            new Cinema
            {
                Id = 1,
                Location = "Bitola",
                Name = "Cinema Bitola",
                CinemaMovies = new List<CinemaMovie>{ }
            },
            new Cinema
            {
                Id = 2,
                Location = "Skopje",
                Name = "Cinema Skopje",
                CinemaMovies = new List<CinemaMovie>{ }
            }
        };
        public static List<Movie> MoviesDb = new List<Movie>()
        {
            new Movie
            {
                 Id = 1,
                 Title = "Star Wars: Episode III - Revenge of the Sith",
                 Description = "Director: George Lucas \n Cast: Ewan McGRegor, Hayden Christensen, Natalie Portman",
                 CinemaMovies = new List<CinemaMovie>{ },
                 Genre = MovieGenreEnum.SciFi
            },
            new Movie
            {
                 Id = 2,
                 Title = "Pirates of the Caribbean: The Curse of the Black Pearl",
                 Description = "Director: Gore Verbinski \n Cast: Johnny Depp, Keira Knightley, Orlando Bloom",
                 CinemaMovies = new List<CinemaMovie>{ },
                 Genre = MovieGenreEnum.Adventure
            },
            new Movie
            {
                 Id = 3,
                 Title = "The Notebook",
                 Description = "Director: Nick Cassavetes \n Cast: Ryan Gosling, Rachel McAdams",
                 CinemaMovies = new List<CinemaMovie>{ },
                 Genre = MovieGenreEnum.Romance
            }
        };
        public static List<CinemaMovie> CinemaMoviesDb = new List<CinemaMovie>()
        {
            new CinemaMovie
            {
                Id = 1,
                Cinema = CinemasDb[0],
                CinemaId = 1,
                Movie = MoviesDb[0],
                MovieId = 1
            },
            new CinemaMovie
            {
                Id = 2,
                Cinema = CinemasDb[0],
                CinemaId = 1,
                Movie = MoviesDb[1],
                MovieId = 2
            },
            new CinemaMovie
            {
                Id = 3,
                Cinema = CinemasDb[1],
                CinemaId = 2,
                Movie = MoviesDb[2],
                MovieId = 3
            }
        };
        public static List<Reservation> ReservationsDb = new List<Reservation>()
        {
            new Reservation
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
            }
        };
        public static List<MovieReservation> MovieReservationsDb = new List<MovieReservation>()
        {
            new MovieReservation
            {
                Id = 1,
                CinemaMovie = CinemaMoviesDb[0],
                CinemaMovieId = 1,
                Reservation = ReservationsDb[0],
                ReservationId = 1,
                UserId = 1
            },
            new MovieReservation
            {
                Id = 2,
                CinemaMovie = CinemaMoviesDb[1],
                CinemaMovieId = 2,
                Reservation = ReservationsDb[1],
                ReservationId = 2,
                UserId = 2
            },
            new MovieReservation
            {
                Id = 3,
                CinemaMovie = CinemaMoviesDb[2],
                CinemaMovieId = 3,
                Reservation = ReservationsDb[2],
                ReservationId = 3,
                UserId = 3
            }
        };
        public static List<User> UsersDb = new List<User>()
        {
                new User
                {
                    Id = 1,
                    FirstName = "Bojan",
                    LastName = "Damchevski",
                    MovieReservation = new List<MovieReservation>
                    {
                        MovieReservationsDb[0]
                    }
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jovana",
                    LastName = "Miskimovska",
                    MovieReservation = new List<MovieReservation>
                    {
                        MovieReservationsDb[1]
                    }
                },
                new User
                {
                    Id = 3,
                    FirstName = "Stefan",
                    LastName = "Trajkov",
                    MovieReservation = new List<MovieReservation>
                    {
                        MovieReservationsDb[2]
                    }
                }
        };
    }
}