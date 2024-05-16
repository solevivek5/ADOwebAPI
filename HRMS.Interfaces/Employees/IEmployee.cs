using HRMS.Core.Dtos;
using HRMS.Core.Dtos.Employees;
using HRMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Interfaces.Employees
{
    public interface IEmployee
    {
        Task<Dictionary<string, object>> GetAll();
        Task<Dictionary<string, object>> Save(Employee objSaveEmployee);
        Task<Dictionary<string, object>> GetById(int EmployeeId);
        Task<Dictionary<string, object>> Update(Employee objUpdateEmployee);
        Task<Dictionary<string, object>> Delete(int EmployeeId);
    }
}
