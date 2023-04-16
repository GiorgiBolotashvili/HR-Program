using HR_Program.Domain.DTO;
using HR_Program.Domain.Interfaces;
using HR_Program.Domain.Repositories;
using HR_Program.Helpers;
using HR_Program.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Program.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepository _userRepository;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userRepository = new UserRepository();
        }

        public IActionResult Index()
        {
            if (UserHelper.isLogIn)
            {
                return RedirectToAction("GetEmployees", "Employee");
            }
            else
            {
                return RedirectToAction("Registration", "Home");
            }
        }

/*        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/


        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (checkEmail(model.Email))
            {
                TempData["Message"] = "This email is already registered. Please log in";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                model.Password = HashPasswordHelper.HashPassword(model.Password);
            }

            if (_userRepository.Create(model))
            {
                UserHelper.activeUser = model;
                UserHelper.isLogIn = true;
                return RedirectToAction("GetEmployees", "Home");
            }
            
            return View(model);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            User logInUser = _userRepository.Select().FirstOrDefault(x => x.Email == model.Email);
            if (logInUser==null)
            {
                TempData["Message"] = "This email is not registered in the system";
                return RedirectToAction("Login", "Home");
            }
            else if (logInUser.Password != HashPasswordHelper.HashPassword(model.Password))
            {
                TempData["Message"] = "Password is wrong. Try again.";
                return RedirectToAction("Login", "Home");
            }
            UserHelper.activeUser = logInUser;
            UserHelper.isLogIn = true;
            return RedirectToAction("GetEmployees", "Employee");
        }

        public IActionResult LogOut()
        {
            UserHelper.activeUser = null;
            UserHelper.isLogIn = false;
            return RedirectToAction("Login", "Home");
        }

        private bool checkEmail(string email)
        {
            return _userRepository.Select().Where(x => x.Email == email).Any();
        }
    }
}
