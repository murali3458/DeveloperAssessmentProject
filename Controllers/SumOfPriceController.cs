using ApplicationDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumOfPriceController : ControllerBase
    {

        private readonly AppDbContext _context;

        public SumOfPriceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTotalPrice()
        {
            var sum = _context.Books.Sum(x=> x.Price);
            return Ok(sum);
        }
    }
}
