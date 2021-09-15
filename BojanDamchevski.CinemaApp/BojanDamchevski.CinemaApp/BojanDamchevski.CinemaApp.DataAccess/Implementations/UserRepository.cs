using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.CinemaApp.DataAccess.Implementations
{
    public class UserRepository : IRepository<User>
    {
        private CinemaAppDbContext _cinemaAppDbContext;
        public UserRepository(CinemaAppDbContext cinemaAppDbContext)
        {
            _cinemaAppDbContext = cinemaAppDbContext;
        }
        public void DeleteById(int id)
        {
            User userDb = _cinemaAppDbContext.Users.FirstOrDefault(x => x.Id == id);
            _cinemaAppDbContext.Users.Remove(userDb);
            _cinemaAppDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _cinemaAppDbContext.Users
                .Include(x => x.MovieReservation)
                .ThenInclude(x => x.CinemaMovie)
                .ThenInclude(x => x.Movie)
                .Include(x => x.MovieReservation)
                .ThenInclude(x => x.CinemaMovie)
                .ThenInclude(x => x.Cinema)
                .ToList();
        }

        public User GetById(int id)
        {
            return _cinemaAppDbContext.Users
                .Include(x => x.MovieReservation)
                .ThenInclude(x => x.CinemaMovie)
                .ThenInclude(x => x.Movie)
                .Include(x => x.MovieReservation)
                .ThenInclude(x => x.CinemaMovie)
                .ThenInclude(x => x.Cinema)
                .FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            _cinemaAppDbContext.Users.Add(entity);
            return _cinemaAppDbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _cinemaAppDbContext.Users.Update(entity);
            _cinemaAppDbContext.SaveChanges();
        }
    }
}
