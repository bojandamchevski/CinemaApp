using System;
using System.ComponentModel.DataAnnotations;

namespace BojanDamchevski.CinemaApp.ViewModels.UserViewModels
{
    public class AddMovieReservationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Reservation date")]
        public int UserId { get; set; }
        public DateTime ReservationTime { get; set; }
        [Display(Name = "Movie and cinema")]
        public string CinemaMovieId { get; set; }
    }
}
