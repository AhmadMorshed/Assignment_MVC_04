using Company.Data.Entities;
using Company.Services.Interfaces;
using Company.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employee = _employeeService.GetAll();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                }
                return RedirectToAction(nameof(Index));

                ModelState.AddModelError("EmployeeError", "ValidationErrors");

                return View(employee);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);
            }


        }
        public IActionResult Details(int? id, string viewName = "Details")
        {

            var employee = _employeeService.GetById(id);

            if (employee is null)

                return RedirectToAction("NotFoundPage", null, "Home");

            return View(viewName, employee);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, Employee employeee)
        {
            if (employeee.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");
            _employeeService.Update(employeee);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee is null)

                return RedirectToAction("NotFoundPage", null, "Home");
            return RedirectToAction(nameof(Index));
        }
    }
}
