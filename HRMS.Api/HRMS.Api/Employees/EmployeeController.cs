using AutoMapper;
using HRMS.Core.Dtos.Employees;
using HRMS.Entities.Models;
using HRMS.Interfaces.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Employees
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployee _repo;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployee repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region Fetch Patient
        [AllowAnonymous]
        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
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

        #region Save Employee
        [AllowAnonymous]
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(EmployeeDto objEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var savePatient = _mapper.Map<Employee>(objEmployee);
                    return Ok(await Task.Run(() => _repo.Save(savePatient)));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Get Employee By Id
        [AllowAnonymous]
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] int EmployeeId)
        {
            try
            {
                var result = await Task.Run(() => _repo.GetById(EmployeeId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Update Employee
        [AllowAnonymous]
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto objEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateEmployee = _mapper.Map<Employee>(objEmployee);
                    return Ok(await Task.Run(() => _repo.Update(updateEmployee)));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Delete Employee
        [AllowAnonymous]
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            try
            {
                var result = await Task.Run(() => _repo.Delete(EmployeeId));
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
