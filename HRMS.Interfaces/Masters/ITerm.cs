using HRMS.Core.Dtos.Term;
using HRMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Interfaces.Masters
{
    public interface ITerm
    {

        Task<Dictionary<string, object>> GetAll();
        Task<Dictionary<string, object>> Save(TermDTO objTrm);
        Task<Dictionary<string, object>> GetById(string STermCode);
        Task<Dictionary<string, object>> Update(TermDTO objTrm);
        Task<Dictionary<string, object>> Delete(string STermCode);
    }
}
