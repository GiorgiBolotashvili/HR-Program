using HR_Program.Domain.Interfaces;
using HR_Program.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Program.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController()
        {
            _repository = new EmployeeRepository();
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return View(_repository.Select());
        }
    }
}
