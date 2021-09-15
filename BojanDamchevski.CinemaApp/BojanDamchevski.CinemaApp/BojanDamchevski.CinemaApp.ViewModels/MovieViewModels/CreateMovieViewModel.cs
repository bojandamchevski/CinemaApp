using BojanDamchevski.CinemaApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BojanDamchevski.CinemaApp.ViewModels.MovieViewModels
{
    public class CreateMovieViewModel
    {
        public int NewId { get; set; }
        [Display(Name = "Title:")]
        public string NewTitle { get; set; }
        [Display(Name = "Description:")]
        public string NewDescription { get; set; }
        [Display(Name = "Genre:")]
        public MovieGenreEnum NewGenre { get; set; }
        [Display(Name = "Cinema:")]
        public int CinemaId { get; set; }
    }
}
