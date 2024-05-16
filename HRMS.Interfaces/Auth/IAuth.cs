using HRMS.Core.Dtos.Auth;
using HRMS.Core.Dtos.HR;
using HRMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Interfaces.Auth
{
    public interface IAuth
    {
        Task<Dictionary<string, object>>? Register(HrDto objRegister);
        Task<Dictionary<string, object>> Login(LoginDto objLogin);
    }
}
