using AutoMapper;
using HRMS.Core.Dtos;
using HRMS.Core.Dtos.Organization;
using HRMS.Entities.Models;
using HRMS.Interfaces.Employees;
using HRMS.Interfaces.Organization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Organization
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private IDepartment _repo;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartment repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region Fetch Departments
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
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

        #region Save Department
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(DepartmentDto objDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var saveDepartment = _mapper.Map<Department>(objDepartment);
                    return Ok(await Task.Run(() => _repo.Save(saveDepartment)));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Get Department By Id
        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById([FromQuery] int DepartmentId)
        {
            try
            {
                var result = await Task.Run(() => _repo.GetById(DepartmentId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Update Department
        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDto objDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateDepartment = _mapper.Map<Department>(objDepartment);
                    return Ok(await Task.Run(() => _repo.Update(updateDepartment)));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
