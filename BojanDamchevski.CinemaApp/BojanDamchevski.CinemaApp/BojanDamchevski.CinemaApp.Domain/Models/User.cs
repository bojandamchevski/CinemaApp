using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<MovieReservation> MovieReservation { get; set; } = new List<MovieReservation>();
    }
}
