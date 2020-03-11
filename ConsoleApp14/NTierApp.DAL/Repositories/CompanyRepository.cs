using NTierApp.DAL.Entities;
using NTierApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTierApp.DAL.Repositories
{
    class CompanyRepository : IRepository<Company>
    {
        private readonly DatabaseContext db;

        public CompanyRepository(DatabaseContext context)
        {
            this.db = context;
        }
        public void Create(Company item)
        {
            db.Companies.Add(item);
        }

        public void Delete(int id)
        {
            db.Companies.Remove(db.Companies.FirstOrDefault(x => x.Id == id));
        }

        public Company Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll()
        {
            return db.Companies.ToList();
        }

        public void Update(Company item)
        {
            Company company = db.Companies.FirstOrDefault(x => x.Id == item.Id);
            if (company != null)
            {
                company.Name = item.Name;
                company.Address = item.Address;
                db.Entry(company).State = System.Data.Entity.EntityState.Modified;
            }     
        }

    }
}
