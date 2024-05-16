using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HRMS.Core.Dtos.Term;
using HRMS.Entities.DbContexts;
using HRMS.Entities.Models;
using HRMS.Helpers.Common;
using HRMS.Interfaces.Masters;
using HRMS.Interfaces.Organization;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repositories.Masters
{
    public class TermRepo : ITerm
    {
        private readonly HRMSContext _context;
        public TermRepo(HRMSContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, object>> Delete(string STermCode)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var term = _context.TblTerms.Where(u => u.STermCode == STermCode).FirstOrDefault();
            if (term != null)
            {
                //term.BActiveStatus = false;
                _context.Entry(term).State = EntityState.Modified;
            };
            await _context.SaveChangesAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Term Code: " + (string)STermCode + " has been deleted successfully.");
            return await Task.FromResult(resJson);
        }

        public async Task<Dictionary<string, object>> GetAll()
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();

            var query = (from trm in _context.TblTerms
                        
                         select new
                         {
                             STermCode = trm.STermCode,
                             STermName = trm.STermName,
                             BActiveStatus = trm.BActiveStatus,
                             SUpdatedBy = trm.SUpdatedBy,
                             DtUpdatedon = trm.DtUpdatedon,
                         }).ToList();
            var term = query.Distinct().OrderByDescending(a => a.SUpdatedBy).ToList();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, term);
            return await Task.FromResult(resJson);


        }

        public async Task<Dictionary<string, object>> GetById(string STermCode)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var query = (from term in _context.TblTerms
                         where term.STermCode == STermCode
                         select new
                         {
                             
                             
                             STermCode = term.STermCode,
                             STermName = term.STermName,
                             BActiveStatus = term.BActiveStatus,
                             SUpdatedBy = term.SUpdatedBy,

                             DtUpdatedon = term.DtUpdatedon
                         });
            var termDetails = await query.ToListAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, termDetails);
            return await Task.FromResult(resJson);
        }

        public async Task<Dictionary<string, object>> Save(TermDTO objTrm)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var term = _context.TblTerms.Where(e => e.STermCode == objTrm.STermCode);
            if (term.Count() == 0)
            {
                _context.TblTerms.Add(new Entities.Models.TblTerm
                {
                    STermCode = objTrm.STermCode,
                    STermName = objTrm.STermName,
                    BActiveStatus = objTrm.BActiveStatus,
                    SUpdatedBy = objTrm.SUpdatedBy,
                    DtUpdatedon = objTrm.DtUpdatedon,
                });
                await _context.SaveChangesAsync();
                resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Term has been created successfully!");
            }
            return await Task.FromResult(resJson);
        }


        public async Task<Dictionary<string, object>> Update(TermDTO objTrm)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var term = _context.TblTerms.Where(u => u.STermCode == objTrm.STermCode).FirstOrDefault();
            if (term != null)
            {
                term.STermCode = objTrm.STermCode;
                term.STermName = objTrm.STermName;
                term.BActiveStatus = objTrm.BActiveStatus;
                term.SUpdatedBy = objTrm.SUpdatedBy;
                term.DtUpdatedon = objTrm.DtUpdatedon;

                _context.Entry(term).State = EntityState.Modified;
            };
            await _context.SaveChangesAsync();
            resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Employee Id: " + (string)objTrm.STermCode + " has been updated successfully.");
            return await Task.FromResult(resJson);
        }

    }
}
