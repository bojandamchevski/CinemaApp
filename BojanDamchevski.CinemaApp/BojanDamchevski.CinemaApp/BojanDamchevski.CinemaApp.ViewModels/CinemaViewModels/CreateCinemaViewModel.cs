using System.ComponentModel.DataAnnotations;

namespace BojanDamchevski.CinemaApp.ViewModels.CinemaViewModels
{
    public class CreateCinemaViewModel
    {
        public int NewId { get; set; }
        [Display(Name = "Name:")]
        public string NewName { get; set; }
        [Display(Name = "Location:")]
        public string NewLocation { get; set; }
        [Display(Name = "Movies:")]
        public int MovieId { get; set; }
    }
}
