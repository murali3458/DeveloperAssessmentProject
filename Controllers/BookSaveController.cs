using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext;
using BussinesObject;

namespace DeveloperAssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSaveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookSaveController(AppDbContext context)
        {
            _context = context;
        }
        

        public IActionResult SaveData()
        {
            foreach(var book in _books)
            {
                _context.Books.Add(book);
            }
            _context.SaveChanges();

            return Ok();
        }


        private static List<BooksModel> _books = new List<BooksModel> {

              new BooksModel { Publisher="SriRam", Title="DrawingIsHeartOfList",AuthorLastName="Krishna", AuthorFirstName="murali",Price=499},
              new BooksModel { Publisher="Arivu", Title="BestCourseInAfterPlusTwo",AuthorLastName="L", AuthorFirstName="Arivu",Price=99}

        };

        
    }
}
