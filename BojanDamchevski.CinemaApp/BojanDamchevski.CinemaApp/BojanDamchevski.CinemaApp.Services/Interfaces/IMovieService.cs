using BojanDamchevski.CinemaApp.ViewModels.MovieViewModels;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieListViewModel> GetAllMovies();
        MovieDetailsViewModel GetMovieDetails(int id);
        void CreateMovie(CreateMovieViewModel insertUserViewModel);
    }
}
