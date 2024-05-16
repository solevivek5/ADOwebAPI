using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Dtos.Employees
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(15, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(15, MinimumLength = 1)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [StringLength(30)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [StringLength(10)]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime? HireDate { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string? Sex { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal? Salary { get; set; }
        public bool? IsActive { get; set; }
    }
}
