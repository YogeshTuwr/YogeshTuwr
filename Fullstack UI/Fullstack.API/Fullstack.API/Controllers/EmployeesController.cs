using Fullstack.API.Data;
using Fullstack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fullstack.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeesController : Controller
    {
        public readonly FullStackDbContext _FullStackDbContext;
        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _FullStackDbContext = fullStackDbContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()
        {
            var Employee = await _FullStackDbContext.Employees.ToListAsync();
            return Ok(Employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeReq)
        {
            employeeReq.Id = new Guid();

            await _FullStackDbContext.Employees.AddAsync(employeeReq);
            await _FullStackDbContext.SaveChangesAsync();
            return Ok(employeeReq);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee UpdateEmployee)
        {


            var Employee = await _FullStackDbContext.Employees.FindAsync(id);
            if (Employee != null)
            {
                Employee.Email = UpdateEmployee.Email;
                Employee.Salary = UpdateEmployee.Salary;
                Employee.Phone = UpdateEmployee.Phone;
                Employee.department = UpdateEmployee.department;
                Employee.Name = UpdateEmployee.Name;

                await _FullStackDbContext.SaveChangesAsync();

            }
            else
            {
                return NotFound();
            }


            return Ok(Employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {


            Employee UpdateEmployee = await _FullStackDbContext.Employees.FindAsync(id);
            if (UpdateEmployee != null)
            {
                _FullStackDbContext.Employees.Remove(UpdateEmployee);
                await _FullStackDbContext.SaveChangesAsync();

            }

            return Ok();
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {


            Employee GetEmployee = await _FullStackDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (GetEmployee == null)
            {
                return NotFound();
            }

            return Ok(GetEmployee);
        }
    }
}
