using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.Domain.Models
{
    public class Cinema : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
    }
}