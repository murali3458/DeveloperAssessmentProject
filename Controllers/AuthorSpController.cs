using ApplicationDbContext;
using ApplicationDbContext.Migrations;
using BussinesObject;
using DeveloperAssessmentProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorSpController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorSpController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
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
