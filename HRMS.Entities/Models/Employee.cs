using System;
using System.Collections.Generic;

namespace HRMS.Entities.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? DepartmentId { get; set; }
        public string? Mobile { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Salary { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
