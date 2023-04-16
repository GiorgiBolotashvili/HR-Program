using HR_Program.Domain.DTO;
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
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            return View(_employeeRepository.Select());
        }

        [HttpPost]
        public ActionResult GetEmployees(Employee model)
        {

            return View();
        }    
        
        [HttpPost]
        public ActionResult Create(Employee model)
        {

            return View(_employeeRepository.Select());
        }
    }
}
