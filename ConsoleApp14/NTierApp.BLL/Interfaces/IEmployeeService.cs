using NTierApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> GetAllEmloyees();
        void AddEmployee(EmployeeModel model);
        void RemoveEmployee(int id);
        void EditEmployee(EmployeeModel model);    
    }
}
