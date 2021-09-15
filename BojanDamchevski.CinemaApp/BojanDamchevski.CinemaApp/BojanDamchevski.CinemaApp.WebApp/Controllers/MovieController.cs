using BojanDamchevski.CinemaApp.Services.Interfaces;
using BojanDamchevski.CinemaApp.ViewModels.MovieViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.CinemaApp.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        private ICinemaService _cinemaService;
        public MovieController(IMovieService movieService, ICinemaService cinemaService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
        }
        public IActionResult Index()
        {
            List<MovieListViewModel> movieListViewModel = _movieService.GetAllMovies();
            return View(movieListViewModel);
        }

        public IActionResult Details(int id)
        {
            MovieDetailsViewModel movieDetailsViewModel = _movieService.GetMovieDetails(id);
            return View(movieDetailsViewModel);
        }
        public IActionResult Create()
        {
            CreateMovieViewModel createMovieViewModel = new CreateMovieViewModel();
            ViewBag.Cinemas = _cinemaService.GetAllCinemas();
            return View(createMovieViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateMovieViewModel createMovieViewModel)
        {
            _movieService.CreateMovie(createMovieViewModel);
            return RedirectToAction("Index");
        }
    }
}
