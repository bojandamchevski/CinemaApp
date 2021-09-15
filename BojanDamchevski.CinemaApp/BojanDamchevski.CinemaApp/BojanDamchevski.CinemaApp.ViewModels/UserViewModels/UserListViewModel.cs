using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.ViewModels.UserViewModels
{
    public class UserListViewModel
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<string> UserMovies { get; set; } = new List<string>();
    }
}
