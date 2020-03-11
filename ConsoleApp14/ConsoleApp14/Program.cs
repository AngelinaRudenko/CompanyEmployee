using Autofac;
using ConsoleApp14.Models;
using NTierApp.BLL;
using NTierApp.BLL.Interfaces;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacConfig.ConfigureContainer("DefaultConnection");
            //var employeeService = container.Resolve(typeof(IEmployeeService)) as IEmployeeService;
            var companiesService = container.Resolve(typeof(ICompanyService)) as ICompanyService;

            //employeeService.AddEmployee(new NTierApp.BLL.Models.EmployeeModel { FirstName = "Alex", LastName = "Protskevich" });
            //companiesService.AddCompany(new NTierApp.BLL.Models.CompanyModel { Name = "BelItSoft", CompanyAddress = "lalala" });
            //companiesService.AddCompany(new NTierApp.BLL.Models.CompanyModel { Name = "Epam", CompanyAddress = "mumumu" });
            //var employees = employeeService.GetAllEmloyees();
            var companies = companiesService.GetAllCompanies();
        }
    }
}
