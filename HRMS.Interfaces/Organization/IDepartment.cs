using HRMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Interfaces.Organization
{
    public interface IDepartment
    {
        Task<Dictionary<string, object>> GetAll();
        Task<Dictionary<string, object>> Save(Department objSaveDepartment);
        Task<Dictionary<string, object>> GetById(int DepartmentId);
        Task<Dictionary<string, object>> Update(Department objUpdateDepartment);
    }
}
