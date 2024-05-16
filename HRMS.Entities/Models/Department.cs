using System;
using System.Collections.Generic;

namespace HRMS.Entities.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
