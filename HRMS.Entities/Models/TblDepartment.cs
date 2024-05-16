using System;
using System.Collections.Generic;

namespace HRMS.Entities.Models
{
    public partial class TblDepartment
    {
        public string? SDepartmentCode { get; set; }
        public string? SDepartmentName { get; set; }
        public bool? BActiveStatus { get; set; }
        public string? SUpdatedBy { get; set; }
        public DateTime? DtUpdatedon { get; set; }
    }
}
