using BojanDamchevski.CinemaApp.Domain.Enums;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.ViewModels.MovieViewModels
{
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MovieGenreEnum Genre { get; set; }
        public List<string> Cinemas { get; set; }
    }
}
