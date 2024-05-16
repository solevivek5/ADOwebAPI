using System;
using System.Collections.Generic;

namespace HRMS.Entities.Models
{
    public partial class TblTerm
    {
        public string STermCode { get; set; } = null!;
        public string STermName { get; set; } = null!;
        public bool BActiveStatus { get; set; }
        public string SUpdatedBy { get; set; } = null!;
        public DateTime DtUpdatedon { get; set; }
    }
}
