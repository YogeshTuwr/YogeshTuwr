using Fullstack.API.Data;
using Fullstack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fullstack.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DepartmentsController : Controller
    {
        public readonly FullStackDbContext _FullStackDbContext;
        public DepartmentsController(FullStackDbContext fullStackDbContext)
        {
            _FullStackDbContext = fullStackDbContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllDepartments()
        {
            var Department = await _FullStackDbContext.Departments.ToListAsync();
            return Ok(Department);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department DepartmentReq)
        {
            try
            {
                //DepartmentReq.Id = _FullStackDbContext.Departments.ToList().Max(e => Convert.ToInt16(e.Id));




                await _FullStackDbContext.Departments.AddAsync(DepartmentReq);
                await _FullStackDbContext.SaveChangesAsync();
                return Ok(DepartmentReq);
            }
            catch (Exception ex)
            {
            }
            return NotFound();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, Department UpdateDepartment)
        {


            var Department = await _FullStackDbContext.Departments.FindAsync(id);
            if (Department != null)
            {
                //Department.Id = UpdateDepartment.Id;
                Department.DepartmentName = UpdateDepartment.DepartmentName;

                await _FullStackDbContext.SaveChangesAsync();

            }
            else
            {
                return NotFound();
            }


            return Ok(Department);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {


            Department UpdateDepartment = await _FullStackDbContext.Departments.FindAsync(id);
            if (UpdateDepartment != null)
            {
                _FullStackDbContext.Departments.Remove(UpdateDepartment);
                await _FullStackDbContext.SaveChangesAsync();

            }

            return Ok();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDepartment(int id)
        {


            Department GetDepartment = await _FullStackDbContext.Departments.FirstOrDefaultAsync(e => e.Id == id);
            if (GetDepartment == null)
            {
                return NotFound();
            }

            return Ok(GetDepartment);
        }
    }
}
