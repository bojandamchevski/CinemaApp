using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.CinemaApp.DataAccess.Implementations
{
    public class MovieRepository : IRepository<Movie>
    {
        private CinemaAppDbContext _cinemaAppDbContext;
        public MovieRepository(CinemaAppDbContext cinemaAppDbContext)
        {
            _cinemaAppDbContext = cinemaAppDbContext;
        }
        public void DeleteById(int id)
        {
            Movie movieDb = _cinemaAppDbContext.Movies.FirstOrDefault(x => x.Id == id);
            _cinemaAppDbContext.Movies.Remove(movieDb);
            _cinemaAppDbContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _cinemaAppDbContext.Movies
                .Include(x=>x.CinemaMovies)
                .ThenInclude(x=>x.Cinema)
                .ToList();
        }

        public Movie GetById(int id)
        {
            return _cinemaAppDbContext.Movies
                .Include(x => x.CinemaMovies)
                .ThenInclude(x => x.Cinema)
                .FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Movie entity)
        {
            _cinemaAppDbContext.Movies.Add(entity);
            return _cinemaAppDbContext.SaveChanges();
        }

        public void Update(Movie entity)
        {
            _cinemaAppDbContext.Movies.Update(entity);
            _cinemaAppDbContext.SaveChanges();
        }
    }
}
