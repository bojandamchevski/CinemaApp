using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using BojanDamchevski.CinemaApp.Mappers;
using BojanDamchevski.CinemaApp.Services.Interfaces;
using BojanDamchevski.CinemaApp.ViewModels.UserViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.CinemaApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserListViewModel> GetAllUsers()
        {
            List<User> usersDb = _userRepository.GetAll();
            return usersDb.Select(x => x.ToUserListViewModel()).ToList();
        }

        public UserDetailsViewModel GetUserDetails(int id)
        {
            User userDb = _userRepository.GetById(id);
            return userDb.ToUserDetailsViewModel();
        }

        public void CreateUser(CreateUserViewModel insertUserViewModel)
        {
            _userRepository.Insert(insertUserViewModel.ToUser());
        }

        public void AddReservation(AddMovieReservationViewModel addMovieReservationViewModel)
        {
            User userDb = _userRepository.GetById(addMovieReservationViewModel.UserId);
            userDb.MovieReservation.Add(new MovieReservation
            {
                
            });
        }
    }
}
