using BojanDamchevski.CinemaApp.Domain.Models;
using BojanDamchevski.CinemaApp.ViewModels.CinemaViewModels;
using System.Linq;

namespace BojanDamchevski.CinemaApp.Mappers
{
    public static class CinemaMapper
    {
        public static CinemaListViewModel ToCinemaListViewModel(this Cinema cinema)
        {
            return new CinemaListViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name
            };
        }

        public static CinemaDetailsViewModel ToCinemaDetailsViewModel(this Cinema cinema)
        {
            return new CinemaDetailsViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies.Select(x => x.Movie.Title).ToList()
            };
        }
    }
}
