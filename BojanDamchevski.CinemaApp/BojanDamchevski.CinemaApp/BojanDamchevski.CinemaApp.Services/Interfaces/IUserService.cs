using BojanDamchevski.CinemaApp.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.Services.Interfaces
{
    public interface IUserService
    {
        List<UserListViewModel> GetAllUsers();
        UserDetailsViewModel GetUserDetails(int id);
        void CreateUser(CreateUserViewModel insertUserViewModel);
        void AddReservation(AddMovieReservationViewModel addMovieReservationViewModel);
    }
}
