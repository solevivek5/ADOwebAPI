using AutoMapper;
using HRMS.Core.Dtos.Employees;
using HRMS.Core.Dtos.Organization;
using HRMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EmployeeDto, Employee>()
               .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(x => x.EmployeeId))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
               .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(x => x.DepartmentId))
               .ForMember(dest => dest.Mobile, opt => opt.MapFrom(x => x.Mobile))
               .ForMember(dest => dest.HireDate, opt => opt.MapFrom(x => x.HireDate))
               .ForMember(dest => dest.Sex, opt => opt.MapFrom(x => x.Sex))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(x => x.BirthDate))
               .ForMember(dest => dest.Salary, opt => opt.MapFrom(x => x.Salary))
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => x.IsActive));

            CreateMap<DepartmentDto, Department>()
               .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(x => x.DepartmentId))
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(x => x.DepartmentName));
        }
    }
}
