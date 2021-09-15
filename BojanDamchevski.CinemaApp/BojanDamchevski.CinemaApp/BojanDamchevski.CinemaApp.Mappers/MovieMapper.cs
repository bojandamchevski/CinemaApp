using BojanDamchevski.CinemaApp.Domain.Models;
using BojanDamchevski.CinemaApp.ViewModels.MovieViewModels;
using System.Linq;

namespace BojanDamchevski.CinemaApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieListViewModel ToMovieListViewModel(this Movie movie)
        {
            return new MovieListViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre
            };
        }

        public static MovieDetailsViewModel ToMovieDetailsViewModel(this Movie movie)
        {
            return new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Description = movie.Description,
                Cinemas = movie.CinemaMovies.Select(x => x.Cinema.Name).ToList()
            };
        }
    }
}
