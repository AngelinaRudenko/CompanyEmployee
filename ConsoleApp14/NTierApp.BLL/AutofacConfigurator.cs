using Autofac;
using NTierApp.BLL.Interfaces;
using NTierApp.DAL;
using NTierApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.BLL
{
    public class AutofacConfigurator
    {
        public static ContainerBuilder GetBuilder(string connectionString)
        {
            //register dependancies from DAL and BLL
            var builder = new ContainerBuilder();

            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("connectionString", connectionString);
            return builder;

        }
    }
}
