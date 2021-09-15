using BojanDamchevski.CinemaApp.Domain.Enums;

namespace BojanDamchevski.CinemaApp.Domain.Models
{
    public class MovieReservation : BaseEntity
    {
        public int CinemaMovieId { get; set; }
        public CinemaMovie CinemaMovie { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}