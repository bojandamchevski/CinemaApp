using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.ViewModels.UserViewModels
{
    public class UserDetailsViewModel
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<string> UserMovieReservationDetails { get; set; } = new List<string>();
    }
}
