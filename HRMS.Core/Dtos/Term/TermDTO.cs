using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Dtos.Term
{
    public  class TermDTO
    {
        public string STermCode { get; set; } = null!;
        public string STermName { get; set; } = null!;
        public bool BActiveStatus { get; set; }
        public string SUpdatedBy { get; set; } = null!;
        public DateTime DtUpdatedon { get; set; }
    }
}
