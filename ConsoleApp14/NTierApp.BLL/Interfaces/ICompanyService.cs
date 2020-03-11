using NTierApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.BLL.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyModel> GetAllCompanies();
        void AddCompany(CompanyModel model);
        void RemoveCompany(int id);
        void EditCompany(CompanyModel model);
    }
}
