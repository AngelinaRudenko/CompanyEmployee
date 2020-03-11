using Autofac;
using NTierApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using NTier.PL;
using System.Web.Mvc;

namespace NTierApp.BLL
{
    public class AutofacConfig
    {
        public static void ConfigureContainer(string connectionString)
        {
            //we make 2 registers of ioc because our PL mustn't know anything about DAL(AutofacConfigurator
            //describes UnitOfWork). In this AutofacConfig we add builder from the privious layer, register
            //controllers and add this dependancies to default mvc5 dependancies-tree
            var builder = AutofacConfigurator.GetBuilder(connectionString);//call method getbuilder from BLL
            builder.RegisterControllers(typeof(MvcApplication).Assembly);//register controllers(solution name) to controller
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));//EF has its own ioc container, we change it into our 
        }
    }
}
