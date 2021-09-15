using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using BojanDamchevski.CinemaApp.Mappers;
using BojanDamchevski.CinemaApp.Services.Interfaces;
using BojanDamchevski.CinemaApp.ViewModels.MovieViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.CinemaApp.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;
        private IRepository<Cinema> _cinemaRepository;
        public MovieService(IRepository<Movie> movieRepository, IRepository<Cinema> cinemaRepository)
        {
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
        }

        public void CreateMovie(CreateMovieViewModel insertUserViewModel)
        {
            Movie newMovie = new Movie();
            newMovie.Title = insertUserViewModel.NewTitle;
            newMovie.Description = insertUserViewModel.NewDescription;
            newMovie.Genre = insertUserViewModel.NewGenre;
            Cinema cinema = _cinemaRepository.GetById(insertUserViewModel.CinemaId);
            newMovie.CinemaMovies.Add(new CinemaMovie
            {
                Movie = newMovie,
                MovieId = newMovie.Id,
                Cinema = cinema,
                CinemaId = cinema.Id
            });
            _movieRepository.Insert(newMovie);
        }

        public List<MovieListViewModel> GetAllMovies()
        {
            List<Movie> moviesDb = _movieRepository.GetAll();
            return moviesDb.Select(x => x.ToMovieListViewModel()).ToList();
        }

        public MovieDetailsViewModel GetMovieDetails(int id)
        {
            Movie movieDb = _movieRepository.GetById(id);
            return movieDb.ToMovieDetailsViewModel();
        }
    }
}
