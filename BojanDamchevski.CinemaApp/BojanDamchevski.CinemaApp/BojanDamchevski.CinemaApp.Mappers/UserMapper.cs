using BojanDamchevski.CinemaApp.Domain.Models;
using BojanDamchevski.CinemaApp.ViewModels.UserViewModels;
using System.Linq;

namespace BojanDamchevski.CinemaApp.Mappers
{
    public static class UserMapper
    {
        public static UserListViewModel ToUserListViewModel(this User userDb)
        {
            return new UserListViewModel
            {
                UserId = userDb.Id,
                UserFullName = $"{userDb.FirstName} {userDb.LastName}",
                UserMovies = userDb.MovieReservation.Select(x => x.CinemaMovie.Movie.Title).ToList()
            };
        }
        public static UserDetailsViewModel ToUserDetailsViewModel(this User userDb)
        {
            return new UserDetailsViewModel
            {
                UserId = userDb.Id,
                UserFullName = $"{userDb.FirstName} {userDb.LastName}",
                UserMovieReservationDetails = userDb.MovieReservation.Select(x => $"Cinema: \n{x.CinemaMovie.Cinema.Name} | Location: \n{x.CinemaMovie.Cinema.Location} |Movie: \n{x.CinemaMovie.Movie.Title} | Description: \n{x.CinemaMovie.Movie.Description}").ToList()
            };
        }

        public static User ToUser(this CreateUserViewModel createUserViewModel)
        {
            return new User
            {
                FirstName = createUserViewModel.FirstName,
                LastName = createUserViewModel.LastName
            };
        }
    }
}
