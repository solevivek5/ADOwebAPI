using AutoMapper;
using HRMS.Core.Dtos.Employees;
using HRMS.Core.Dtos.Term;
using HRMS.Entities.Models;
using HRMS.Interfaces.Employees;
using HRMS.Interfaces.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Area.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private ITerm _repo;
        private readonly IMapper _mapper;
        public TermController(ITerm repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region Get All Term
        [AllowAnonymous]
        [HttpGet("GetTerm")]
        public async Task<IActionResult> GetTerm()
        {
            try
            {
                var result = await Task.Run(() => _repo.GetAll());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Save Term
        [AllowAnonymous]
        [HttpPost("CreateTerm")]
        public async Task<IActionResult> CreateTerm(TermDTO objTerm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var saveTerm = _mapper.Map<TermDTO>(objTerm);
                    return Ok(await Task.Run(() => _repo.Save(saveTerm)));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Get Term By Id
        [AllowAnonymous]
        [HttpGet("GetTermById")]
        public async Task<IActionResult> GetTermById([FromQuery] string STermCode)
        {
            try
            {
                var result = await Task.Run(() => _repo.GetById(STermCode));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Update Term
        [AllowAnonymous]
        [HttpPut("UpdateTerm")]
        public async Task<IActionResult> UpdateTerm(TermDTO objTerm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateTerm = _mapper.Map<TermDTO>(objTerm);
                    return Ok(await Task.Run(() => _repo.Update(updateTerm)));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Delete Term
        [AllowAnonymous]
        [HttpDelete("DeleteTerm")]
        public async Task<IActionResult> DeleteTerm(string objTerm)
        {
            try
            {
                var result = await Task.Run(() => _repo.Delete(objTerm));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
