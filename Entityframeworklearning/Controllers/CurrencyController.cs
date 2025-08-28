using Entityframeworklearning.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entityframeworklearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }
        [HttpGet("Currecies")]
        public IActionResult getallcurrencies()
        {
            var result=appDbContext.CurrencyTypes.ToList();
            return Ok(result);
        }
      
    }
}
