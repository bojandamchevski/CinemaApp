using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.CinemaApp.DataAccess.Implementations
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private CinemaAppDbContext _cinemaAppDbContext;
        public ReservationRepository(CinemaAppDbContext cinemaAppDbContext)
        {
            _cinemaAppDbContext = cinemaAppDbContext;
        }
        public void DeleteById(int id)
        {
            Reservation reservationDb = _cinemaAppDbContext.Reservations.FirstOrDefault(x => x.Id == id);
            _cinemaAppDbContext.Reservations.Remove(reservationDb);
            _cinemaAppDbContext.SaveChanges();
        }

        public List<Reservation> GetAll()
        {
            return _cinemaAppDbContext.Reservations.ToList();
        }

        public Reservation GetById(int id)
        {
            return _cinemaAppDbContext.Reservations.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Reservation entity)
        {
            _cinemaAppDbContext.Reservations.Add(entity);
            return _cinemaAppDbContext.SaveChanges();
        }

        public void Update(Reservation entity)
        {
            _cinemaAppDbContext.Reservations.Update(entity);
            _cinemaAppDbContext.SaveChanges();
        }
    }
}
