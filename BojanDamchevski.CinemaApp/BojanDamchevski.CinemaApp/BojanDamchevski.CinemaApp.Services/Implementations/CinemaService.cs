using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using BojanDamchevski.CinemaApp.Mappers;
using BojanDamchevski.CinemaApp.Services.Interfaces;
using BojanDamchevski.CinemaApp.ViewModels.CinemaViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.CinemaApp.Services.Implementations
{
    public class CinemaService : ICinemaService
    {
        private IRepository<Cinema> _cinemaRepository;
        private IRepository<Movie> _movieRepository;
        public CinemaService(IRepository<Cinema> cinemaRepository, IRepository<Movie> movieRepository)
        {
            _cinemaRepository = cinemaRepository;
            _movieRepository = movieRepository;
        }

        public void CreateCinema(CreateCinemaViewModel insertCinemaViewModel)
        {
            Cinema newCinema = new Cinema();
            newCinema.Name = insertCinemaViewModel.NewName;
            newCinema.Location = insertCinemaViewModel.NewLocation;
            Movie movie = _movieRepository.GetById(insertCinemaViewModel.MovieId);
            newCinema.CinemaMovies.Add(new CinemaMovie
            {
                Movie = movie,
                MovieId = movie.Id,
                Cinema = newCinema,
                CinemaId = newCinema.Id
            });
            _cinemaRepository.Insert(newCinema);
        }

        public List<CinemaListViewModel> GetAllCinemas()
        {
            List<Cinema> cinemasDb = _cinemaRepository.GetAll();
            return cinemasDb.Select(x => x.ToCinemaListViewModel()).ToList();
        }

        public CinemaDetailsViewModel GetCinemaDetails(int id)
        {
            Cinema cinemaDb = _cinemaRepository.GetById(id);
            return cinemaDb.ToCinemaDetailsViewModel();
        }
    }
}
