using BojanDamchevski.CinemaApp.Domain.Enums;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MovieGenreEnum Genre { get; set; }
        public List<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
    }
}