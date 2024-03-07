using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogService.Database;
namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatelogController : ControllerBase
    {
        public readonly DatabaseContext _DatabaseContext;
        public CatelogController(DatabaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }
        [HttpGet]
        public  async Task<IActionResult> GetProduct()
        {
            var productsLst = await _DatabaseContext.Products.ToListAsync();
            return Ok(productsLst);
        }
    }
}
