using NTierApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Web.Mvc;
using NTierApp.BLL;
using NTierApp.BLL.Interfaces;
using NTierApp.BLL.Models;

namespace NTier.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public ActionResult Index()
        {
            var employees = this.employeeService.GetAllEmloyees();            
            return View(employees);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            this.employeeService.RemoveEmployee(id);
            var employees = this.employeeService.GetAllEmloyees();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            EmployeeModel employee = new EmployeeModel { Id = employeeService.GetAllEmloyees().Count() + 1 };
            ViewBag.Action = "Add";
            return View("Edit", employee);
        }

        [HttpPost]
        public ActionResult Add(EmployeeModel employee)
        {
            if (employee != null)
            {
                employeeService.AddEmployee(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = employeeService.GetAllEmloyees().FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                ViewBag.Action = "Edit";
                return View(employee);
            }
            return HttpNotFound();

        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            employeeService.EditEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}