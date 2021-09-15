using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.CinemaApp.DataAccess.Implementations
{
    public class CinemaRepository : IRepository<Cinema>
    {
        private CinemaAppDbContext _cinemaAppDbContext;
        public CinemaRepository(CinemaAppDbContext cinemaAppDbContext)
        {
            _cinemaAppDbContext = cinemaAppDbContext;
        }
        public void DeleteById(int id)
        {
            Cinema cinemaDb = _cinemaAppDbContext.Cinemas.FirstOrDefault(x => x.Id == id);
            _cinemaAppDbContext.Cinemas.Remove(cinemaDb);
            _cinemaAppDbContext.SaveChanges();
        }

        public List<Cinema> GetAll()
        {
            return _cinemaAppDbContext.Cinemas
                .Include(x => x.CinemaMovies)
                .ThenInclude(x => x.Movie)
                .ToList();
        }

        public Cinema GetById(int id)
        {
            return _cinemaAppDbContext.Cinemas
                .Include(x => x.CinemaMovies)
                .ThenInclude(x => x.Movie)
                .FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Cinema entity)
        {
            _cinemaAppDbContext.Cinemas.Add(entity);
            return _cinemaAppDbContext.SaveChanges();
        }

        public void Update(Cinema entity)
        {
            _cinemaAppDbContext.Cinemas.Update(entity);
            _cinemaAppDbContext.SaveChanges();
        }
    }
}
