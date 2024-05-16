using AutoMapper;
using HRMS.Core.Dtos.Auth;
using HRMS.Core.Dtos.HR;
using HRMS.Entities.Models;
using HRMS.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HRMS.Api.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuth _repo;
       
        public AuthController(IAuth repo)
        {
            _repo = repo;
        }

        #region Register HR Personal
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(HrDto objHr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await Task.Run(() => _repo.Register(objHr)));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Login HR Personal
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto objLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await Task.Run(() => _repo.Login(objLogin)));
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
