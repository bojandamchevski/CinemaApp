using BojanDamchevski.CinemaApp.Services.Interfaces;
using BojanDamchevski.CinemaApp.ViewModels.CinemaViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.CinemaApp.WebApp.Controllers
{
    public class CinemaController : Controller
    {
        private ICinemaService _cinemaService;
        private IMovieService _movieService;
        public CinemaController(ICinemaService cinemaService, IMovieService movieService)
        {
            _cinemaService = cinemaService;
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            List<CinemaListViewModel> cinemaListViewModels = _cinemaService.GetAllCinemas();
            return View(cinemaListViewModels);
        }
        public IActionResult Details(int id)
        {
            CinemaDetailsViewModel cinemaDetailsViewModel = _cinemaService.GetCinemaDetails(id);
            return View(cinemaDetailsViewModel);
        }

        public IActionResult Create()
        {
            CreateCinemaViewModel createCinemaViewModel = new CreateCinemaViewModel();
            ViewBag.Movies = _movieService.GetAllMovies();
            return View(createCinemaViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateCinemaViewModel createCinemaViewModel)
        {
            _cinemaService.CreateCinema(createCinemaViewModel);
            return RedirectToAction("Index");
        }
    }
}
