using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Program.Domain.Repositories;
using HR_Program.Domain.DTO;

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
            EmployeeRepository employee = new EmployeeRepository();

            var response = employee.GetFromView(new Employee());
            return View();
        }

        [HttpPost]
        public IActionResult Register(int model) {

            return View();
        }
    }
}
