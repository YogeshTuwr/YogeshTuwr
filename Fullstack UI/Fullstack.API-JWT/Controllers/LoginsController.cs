using Fullstack.API.Data;
using Fullstack.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fullstack.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class LoginsController : Controller
    {
        public readonly FullStackDbContext _FullStackDbContext;
        IConfiguration _configuration;
        public LoginsController(FullStackDbContext fullStackDbContext, IConfiguration configuration)
        {
            this._FullStackDbContext = fullStackDbContext;
            _configuration = configuration;
        }

       


        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] User _userData)
        {
            if (_userData != null)
            {
                var resultLoginCheck = _FullStackDbContext.Users
                    .Where(e => e.FullName == _userData.EmailId && e.Password == _userData.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    _userData.UserMessage = "Login Success";

                    //var claims = new[] {
                    //    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    //    new Claim("UserId", _userData.ID.ToString()),
                    //    new Claim("DisplayName", _userData.FullName),
                    //    new Claim("UserName", _userData.FullName),
                    //    new Claim("Email", _userData.EmailId)
                    //};


                    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //var token = new JwtSecurityToken(
                    //    _configuration["Jwt:Issuer"],
                    //    _configuration["Jwt:Audience"],
                    //    claims,
                    //    expires: DateTime.UtcNow.AddMinutes(90),
                    //    signingCredentials: signIn);


                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                      _configuration["Jwt:Issuer"],
                      null,
                      expires: DateTime.Now.AddMinutes(120),
                      signingCredentials: credentials);

                    //var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
                    _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                    return Ok(_userData);
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> AddUser([FromBody] UserMaster UserMasterReq)
        //{

        //    await _FullStackDbContext.Users.AddAsync(UserMasterReq);
        //    await _FullStackDbContext.SaveChangesAsync();
        //    return Ok(UserMasterReq);
        //}

    }
}
