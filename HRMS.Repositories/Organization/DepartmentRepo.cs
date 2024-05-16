using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.DbContexts;
using HRMS.Entities.Models;
using HRMS.Helpers.Common;
using HRMS.Interfaces.Organization;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repositories.Organization
{
    public class DepartmentRepo : IDepartment
    {

        private readonly HRMSContext _context;
        public DepartmentRepo(HRMSContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, object>> GetAll()
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var query = (from dept in _context.Departments
                         select new
                         {
                             DepartmentId = dept.DepartmentId,
                             DepartmentName = dept.DepartmentName,
                             CreatedOn = dept.CreatedOn,
                             UpdatedOn = dept.UpdatedOn
                         }).ToList();
            var departments = query.Distinct().OrderByDescending(a => a.CreatedOn).ToList();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, departments);
            return await Task.FromResult(resJson);
        }
        public async Task<Dictionary<string, object>> Save(Department objSaveDepartment)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var department = _context.Departments.Where(e => e.DepartmentName == objSaveDepartment.DepartmentName);
            if (department.Count() == 0)
            {
                _context.Departments.Add(new Department
                {
                    DepartmentName = objSaveDepartment.DepartmentName,
                    CreatedOn = DateTime.Now
                });
                await _context.SaveChangesAsync();
                resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Department has been created successfully!");
            }
            return await Task.FromResult(resJson);
        }

        public async Task<Dictionary<string, object>> GetById(int DepartmentId)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var query = (from dept in _context.Departments
                         where dept.DepartmentId == DepartmentId
                         select new
                         {
                             DepartmentId = dept.DepartmentId,
                             DepartmentName = dept.DepartmentName,
                             CreatedOn = dept.CreatedOn,
                             UpdatedOn = dept.UpdatedOn
                         });
            var departmentDetails = await query.ToListAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, departmentDetails);
            return await Task.FromResult(resJson);
        }

        public async Task<Dictionary<string, object>> Update(Department objUpdateDepartment)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var dept = _context.Departments.Where(u => u.DepartmentId == objUpdateDepartment.DepartmentId).FirstOrDefault();
            if (dept != null)
            {
                dept.DepartmentName = objUpdateDepartment.DepartmentName;
                dept.UpdatedOn = DateTime.Now;
                _context.Entry(dept).State = EntityState.Modified;
            };
            await _context.SaveChangesAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Department Id: " + (int)objUpdateDepartment.DepartmentId + " has been updated successfully.");
            return await Task.FromResult(resJson);
        }
    }
}
