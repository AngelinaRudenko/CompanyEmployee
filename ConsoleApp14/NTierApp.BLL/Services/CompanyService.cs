using NTierApp.BLL.Models;
using NTierApp.DAL.Entities;
using NTierApp.BLL;
using NTierApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using NTierApp.BLL.Models;
using NTierApp.DAL.Entities;

namespace NTierApp.BLL.Interfaces
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork database;
        public CompanyService(IUnitOfWork uow)
        {
            database = uow;
        }

        public void AddCompany(CompanyModel model)
        {
            Company company = new Company { Name = model.Name, Address = model.CompanyAddress };
            database.Companies.Create(company);
            database.Save();
        }

        public IEnumerable<CompanyModel> GetAllCompanies()
        {
            var companies = database.Companies.GetAll().ToList();
            var mapper = Automapper.GetMapper();
            var companiesModel = companies.Select(x => mapper.Map(x, typeof(Company), typeof(CompanyModel)) as CompanyModel).ToList();
            return companiesModel;
        }

        public void RemoveCompany(int id)
        {
            database.Companies.Delete(id);
            database.Save();
        }

        public void EditCompany(CompanyModel model)
        {
            Company company = new Company { Id = model.Id, Name = model.Name, Address = model.CompanyAddress };
            database.Companies.Update(company);
            database.Save();
        }
    }
}
