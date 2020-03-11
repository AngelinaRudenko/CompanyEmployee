using NTierApp.DAL.Entities;
using NTierApp.DAL.Interfaces;
using NTierApp.DAL.Repositories;
using System;

namespace NTierApp.DAL
{
    public class UnitOfWork : IUnitOfWork
        //создает контекст бд и разделяет его между всеми репозиториями
        //таким образом все репозиторию имеют общий контекст
    {
        private DatabaseContext db;
        private EmployeeRepository employeeRepository;
        private CompanyRepository companyRepository;

        public UnitOfWork(string connectionString)
        {
            db = new DatabaseContext(connectionString);
        }
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                   employeeRepository = new EmployeeRepository(db);
                }
                return employeeRepository;
            }
        }

        public IRepository<Company> Companies
        {
            get
            {
                if (companyRepository == null)
                {
                    companyRepository = new CompanyRepository(db);
                }
                return companyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

