using HRMS.Entities.DbContexts;
using HRMS.Entities.Models;
using HRMS.Helpers.Common;
using HRMS.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HRMS.Core.Dtos.Auth;
using HRMS.Core.Dtos.HR;

namespace HRMS.Repositories.Auth
{
    public class AuthRepo : IAuth
    {
        private readonly HRMSContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepo(HRMSContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<Dictionary<string, object>> Register(HrDto objSaveHr)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            HRMSAuth.CreatePasswordHash(objSaveHr.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var hr = _context.Hrs.Where(e => e.Email == objSaveHr.Email);
            if (hr.Count() == 0)
            {
                _context.Hrs.Add(new Entities.Models.Hr
                {
                    FullName = objSaveHr.FullName,
                    Email = objSaveHr.Email,
                    Company = objSaveHr.Company,
                    PhoneNumber = objSaveHr.PhoneNumber,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    CreatedOn = DateTime.Now
                });
                await _context.SaveChangesAsync();
                resJson = Response.SuccessResponse("Success", (int)HttpStatusCode.OK, "Registration has completed successfully!");
            }
            return await Task.FromResult(resJson);
        }
        public async Task<Dictionary<string, object>> Login(LoginDto objLogin)
        {
            Dictionary<string, object> resJson = new Dictionary<string, object>();
            var user = _context.Hrs.Where(x => x.Email == objLogin.Email).FirstOrDefault();
            if(user== null)
            {
                resJson = Response.ErrorResponse("Error", (int)HttpStatusCode.NotFound, "User not found!");
            }
            if (!HRMSAuth.VerifyPasswordHash(objLogin.Password, user.PasswordHash, user.PasswordSalt))
            {
                resJson = Response.ErrorResponse("Error", (int)HttpStatusCode.BadRequest, "You have entered wrong password!");
            }
            else
            {
                LoginResponseDto loginResponse = new LoginResponseDto
                {
                    Error = false,
                    Message = "",
                    Username = objLogin.Email,
                    Token = getToken(user.FullName, user.Email, user.Company, user.PhoneNumber),
                };
                resJson = Response.SuccessResponse("Authorized", (int)HttpStatusCode.OK, loginResponse);
            }
            return await Task.FromResult(resJson);
        }

        public string getToken(string FullName, string Email, string Company, string PhoneNumber)
        {
            var authClaims = new List<Claim>
                {
                    new Claim("FullName", FullName),
                    new Claim("Email", Email),
                    new Claim("Company", Company),
                    new Claim("PhoneNumber", PhoneNumber),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["AppSettings:ValidIssuer"],
                Audience = _configuration["AppSettings:ValidAudience"],
                Expires = DateTime.Now.AddDays(3),
                Subject = new ClaimsIdentity(authClaims),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
