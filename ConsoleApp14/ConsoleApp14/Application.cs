using NTierApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Application
    {
        protected readonly IEmployeeService _employeeService;

        public Application(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }

        public void Run()
        {
            var employee = _employeeService.GetAllEmloyees();

        }
    }
}
