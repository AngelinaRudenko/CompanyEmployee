using AutoMapper;
using NTierApp.BLL.Models;
using NTierApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.BLL
{
    class Automapper
    {
        static Mapper mapper;

        public static Mapper GetMapper()
        {
            if (mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Employee, EmployeeModel>();
                    cfg.CreateMap<EmployeeModel, Employee>();
                    
                    cfg.CreateMap<Company, CompanyModel>().ForMember(a=>a.CompanyAddress, m=>m.MapFrom(a=>a.Address));
                    cfg.CreateMap<CompanyModel, Company>().ForMember(a=>a.Address, m=>m.MapFrom(a=>a.CompanyAddress));
                });

                mapper = new Mapper(config);
            }

            return mapper;
        }
    }
}
