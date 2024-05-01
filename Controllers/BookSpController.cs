using ApplicationDbContext;
using BussinesObject;
using DeveloperAssessmentProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSpController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookSpController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _context.Books.FromSqlRaw("EXEC PublisherwiseProcedure").ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        //[HttpGet]        
        //public async Task<ActionResult<List<BooksModel>>> GetBooks()
        //{
        //    var repos = new BookRepository(_context);
        //    var books = await repos.GetBooksFromStoredProcedureAsync();
        //    return Ok(books);
        //}

    }
}
