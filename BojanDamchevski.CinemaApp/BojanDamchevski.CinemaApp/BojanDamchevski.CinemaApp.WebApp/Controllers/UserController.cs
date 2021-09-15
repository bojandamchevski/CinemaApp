using BojanDamchevski.CinemaApp.Services.Interfaces;
using BojanDamchevski.CinemaApp.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.CinemaApp.WebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Users";
            List<UserListViewModel> userListViewModels = _userService.GetAllUsers();
            return View(userListViewModels);
        }

        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Details";
            UserDetailsViewModel userDetailsViewModels = _userService.GetUserDetails(id);
            return View(userDetailsViewModels);
        }

        public IActionResult Create()
        {
            CreateUserViewModel insertUserViewModel = new CreateUserViewModel();
            return View(insertUserViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateUserViewModel insertUserViewModel)
        {
            _userService.CreateUser(insertUserViewModel);
            return RedirectToAction("Index");
        }
    }
}
