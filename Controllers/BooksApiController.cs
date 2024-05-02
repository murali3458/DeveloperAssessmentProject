using ApplicationDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetPublisherWiseSortList")]
        public IActionResult GetPublisherWiseSortList()
        {
            var res = _context.Books.OrderBy(a => a.Publisher)
                                    .ThenBy(a => a.AuthorLastName)
                                    .ThenBy(a => a.AuthorFirstName)                                    
                                    .ThenBy(a => a.Title)
                                    .ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetAuthorWiseSortList")]
        public IActionResult GetAuthorWiseSortList()
        {
            var res = _context.Books.OrderBy(a => a.AuthorLastName)
                                    .ThenBy(a => a.AuthorFirstName)                                  
                                    .ThenBy(a => a.Title)
                                    .ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetSumOfPrice")]
        public IActionResult GetSumOfPrice()
        {
            var res = _context.Books.Sum(x => x.Price);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetPublisherWiseSpSortList")]
        public async Task<IActionResult> GetPublisherWiseSpSortList()
        {
            try
            {

                var result = await _context.Books.FromSqlRaw("EXEC PublisherwiseProcedure")
                                                    .ToListAsync();
                var data = result.Select(x => new BussinesObject.BooksViewModel
                {
                    Publisher = x.Publisher,
                    AuthorFirstName = x.AuthorFirstName,
                    AuthorLastName = x.AuthorLastName,
                    Title = x.Title,
                    Price = x.Price

                }).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAuthorWiseSpSortList")]
        public async Task<IActionResult> GetAuthorWiseSpSortList()
        {
            try
            {
                var result = await _context.Books.FromSqlRaw("EXEC AuthorWiseListProcedure").ToListAsync();

                //get the list without MLAcitation property. 
                //if you want all the property just comment the below line.
                var data = result.Select(x => new BussinesObject.BooksViewModel
                {
                    Publisher = x.Publisher,
                    AuthorLastName = x.AuthorLastName,
                    AuthorFirstName = x.AuthorFirstName,
                    Price = x.Price,
                    Title = x.Title

                }).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
