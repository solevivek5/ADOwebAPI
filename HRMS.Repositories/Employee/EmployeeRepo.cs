using HRMS.Core.Dtos;
using HRMS.Core.Dtos.Employees;
using HRMS.Entities.DbContexts;
using HRMS.Entities.Models;
using HRMS.Helpers.Common;
using HRMS.Interfaces.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repositories.EmployeeRepo
{
    public class EmployeeRepo : IEmployee
    {
        private readonly HRMSContext _context;
        public EmployeeRepo(HRMSContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, object>> GetAll()
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var query = (from emp in _context.Employees
                         join dept in _context.Departments on emp.DepartmentId equals dept.DepartmentId
                         select new
                         {
                             EmployeeId = emp.EmployeeId,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             Email = emp.Email,
                             DepartmentId = dept.DepartmentId,
                             DepartmentName = dept.DepartmentName,
                             Mobile = emp.Mobile,
                             HireDate = emp.HireDate,
                             Sex = emp.Sex,
                             BirthDate = emp.BirthDate,
                             Salary = emp.Salary,
                             IsActive = emp.IsActive,
                             CreatedOn = emp.CreatedOn,
                             UpdatedOn = emp.UpdatedOn
                         }).OrderByDescending(a => a.CreatedOn).ToList();
            var employees = query.Distinct().OrderByDescending(a => a.CreatedOn).Where(a => a.IsActive == true).ToList();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, employees);
            return await Task.FromResult(resJson);
        }
        public async Task<Dictionary<string, object>> Save(Employee objSaveEmployee)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var employee = _context.Employees.Where(e => e.Email == objSaveEmployee.Email);
            if (employee.Count() == 0)
            {
                _context.Employees.Add(new Entities.Models.Employee
                {
                    FirstName = objSaveEmployee.FirstName,
                    LastName = objSaveEmployee.LastName,
                    Email = objSaveEmployee.Email,
                    DepartmentId = objSaveEmployee.DepartmentId,
                    Mobile = objSaveEmployee.Mobile,
                    HireDate = objSaveEmployee.HireDate,
                    Sex = objSaveEmployee.Sex,
                    BirthDate = objSaveEmployee.BirthDate,
                    Salary = objSaveEmployee.Salary,
                    IsActive = objSaveEmployee.IsActive,
                    CreatedOn = DateTime.Now,
                });
                await _context.SaveChangesAsync();
                resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Employee has been created successfully!");
            }
            return await Task.FromResult(resJson);
        }
        public async Task<Dictionary<string, object>> GetById(int EmployeeId)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var query = (from employee in _context.Employees
                         where employee.EmployeeId == EmployeeId
                         select new
                         {
                             EmployeeId = employee.EmployeeId,
                             FirstName = employee.FirstName,
                             LastName = employee.LastName,
                             Email = employee.Email,
                             DepartmentId = employee.DepartmentId,
                             Mobile = employee.Mobile,
                             HireDate = employee.HireDate,
                             Sex = employee.Sex,
                             BirthDate = employee.BirthDate,
                             Salary = employee.Salary,
                             IsActive = employee.IsActive,
                             CreatedOn = employee.CreatedOn,
                             UpdatedOn = employee.UpdatedOn
                         });
            var employeeDetails = await query.ToListAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, employeeDetails);
            return await Task.FromResult(resJson);
        }
        public async Task<Dictionary<string, object>> Update(Employee objUpdateEmployee)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var employee = _context.Employees.Where(u => u.EmployeeId == objUpdateEmployee.EmployeeId).FirstOrDefault();
            if (employee != null)
            {
                employee.FirstName = objUpdateEmployee.FirstName;
                employee.LastName = objUpdateEmployee.LastName;
                employee.Email = objUpdateEmployee.Email;
                employee.DepartmentId = objUpdateEmployee.DepartmentId;
                employee.Mobile = objUpdateEmployee.Mobile;
                employee.HireDate = objUpdateEmployee.HireDate;
                employee.Sex = objUpdateEmployee.Sex;
                employee.BirthDate = objUpdateEmployee.BirthDate;
                employee.Salary = objUpdateEmployee.Salary;
                employee.IsActive = objUpdateEmployee.IsActive;
                employee.CreatedOn = DateTime.Now;
                _context.Entry(employee).State = EntityState.Modified;
            };
            await _context.SaveChangesAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Employee Id: " + (int)objUpdateEmployee.EmployeeId + " has been updated successfully.");
            return await Task.FromResult(resJson);
        }
        public async Task<Dictionary<string, object>> Delete(int EmployeeId)
        {
            //Soft Delete
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var employee = _context.Employees.Where(u => u.EmployeeId == EmployeeId).FirstOrDefault();
            if (employee != null)
            {
                employee.IsActive = false;
                _context.Entry(employee).State = EntityState.Modified;
            };
            await _context.SaveChangesAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Employee Id: " + (int)EmployeeId + " has been deleted successfully.");
            return await Task.FromResult(resJson);
        }
    }
}
