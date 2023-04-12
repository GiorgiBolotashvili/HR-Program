using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Program.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(int model) {

            return View();
        }
    }
}
