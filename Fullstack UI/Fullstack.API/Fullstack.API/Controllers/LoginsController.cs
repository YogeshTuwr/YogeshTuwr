using Fullstack.API.Data;
using Fullstack.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fullstack.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class LoginsController : Controller
    {
        public readonly FullStackDbContext _FullStackDbContext;
        public LoginsController(FullStackDbContext fullStackDbContext)
        {
            this._FullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            UserMaster GetUserMaster = await _FullStackDbContext.Users.FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
            if (GetUserMaster == null)
            {
                return NotFound();
            }

            return Ok(GetUserMaster);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserMaster UserMasterReq)
        {
            
            await _FullStackDbContext.Users.AddAsync(UserMasterReq);
            await _FullStackDbContext.SaveChangesAsync();
            return Ok(UserMasterReq);
        }

    }
}
