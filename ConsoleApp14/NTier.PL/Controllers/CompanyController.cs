using NTierApp.BLL.Interfaces;
using NTierApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.PL.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public ActionResult Index()
        {
            var companies = companyService.GetAllCompanies();
            return View(companies);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            this.companyService.RemoveCompany(id);
            var employees = this.companyService.GetAllCompanies();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            CompanyModel company = new CompanyModel { Id = companyService.GetAllCompanies().Count() + 1 };
            ViewBag.Action = "Add";
            return View("Edit", company);
        }

        [HttpPost]
        public ActionResult Add(CompanyModel company)
        {
            if (company != null)
            {
                companyService.AddCompany(company);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company = companyService.GetAllCompanies().FirstOrDefault(x => x.Id == id);
            if (company != null)
            {
                ViewBag.Action = "Edit";
                return View(company);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(CompanyModel company)
        {
            companyService.EditCompany(company);
            return RedirectToAction("Index");
        }
    }
}