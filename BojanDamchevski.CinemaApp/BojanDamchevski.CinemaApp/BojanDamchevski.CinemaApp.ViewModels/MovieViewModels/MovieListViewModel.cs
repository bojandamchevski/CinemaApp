using BojanDamchevski.CinemaApp.Domain.Enums;

namespace BojanDamchevski.CinemaApp.ViewModels.MovieViewModels
{
    public class MovieListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MovieGenreEnum Genre { get; set; }
    }
}
