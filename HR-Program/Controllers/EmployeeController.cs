using HR_Program.Domain.DTO;
using HR_Program.Domain.Interfaces;
using HR_Program.Domain.Repositories;
using HR_Program.Domain.ViewModels;
using HR_Program.Helpers;
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
        public ActionResult GetEmployees(string searchString, int page = 1, int rowsPerPage = 10)
        {
            var employees = _employeeRepository.Select();
            EmployeeHelper.rowsPage = rowsPerPage;

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e =>
                    e.FirstName.Contains(searchString) ||
                    e.LastName.Contains(searchString)).ToList();
            }

            var model = employees.Skip((page - 1) * rowsPerPage ).Take(rowsPerPage ).ToList();


            var viewModel = new EmployeeListViewModel
            {
                Employees = model,
                SearchString = searchString,
                Page = page,
                RowsPerPage = rowsPerPage,
                TotalPages =Convert.ToInt32( Math.Ceiling((double)employees.Count() / rowsPerPage))
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GetEmployees(Employee model)
        {

            return View();
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else if (checkPersonalNumber(model.PersonalNumber))
            {
                TempData["Message"] = "This personalNumber is already registered";
                return RedirectToAction("Create", "Employee");
            }

            if (_employeeRepository.Create(model))
            {
                return RedirectToAction("GetEmployees", "Employee");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeRepository.Select().FirstOrDefault(e => e.IdEmployee == id);

            if (employee == null)
            {
                return View();
            }
            EmployeeHelper.EditingPersonalNumber = employee.PersonalNumber;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else if (model.PersonalNumber != EmployeeHelper.EditingPersonalNumber && checkPersonalNumber(model.PersonalNumber))
            {
                TempData["Message"] = "This personalNumber is already registered";
                return View(model);
            }

            if (_employeeRepository.Update(model))
            {
                return RedirectToAction("GetEmployees", "Employee");
            }

            return View(model);
        }


        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("GetEmployees", "Employee");
        }

        private bool checkPersonalNumber(string personalNumber)
        {
            return _employeeRepository.Select().Where(x => x.PersonalNumber == personalNumber && x.IsDeleted == false).Any();
        }
    }
}
