using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Dtos.Organization
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(50, MinimumLength = 5)]
        public string? DepartmentName { get; set; } = string.Empty;
    }
}
