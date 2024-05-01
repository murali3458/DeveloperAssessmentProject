using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        public static List<Book> _books = new List<Book>
        {
            new Book
            {
                Publisher = "Publisher A",
                Title = "Book Title 1",
                AuthorLastName = "Doe",
                AuthorFirstName = "John",
                Price = 19.99m
            },
            new Book
            {
                Publisher = "Publisher B",
                Title = "Book Title 2",
                AuthorLastName = "Smith",
                AuthorFirstName = "Jane",
                Price = 24.99m
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _books.OrderBy(x => x.AuthorLastName)
                          .ThenBy(x => x.AuthorFirstName)
                          .ThenBy(x => x.Title).ToList();
        }

        public class Book
        {
            public string? Publisher { get; set; }
            public string? Title { get; set; }
            public string? AuthorLastName { get; set; }
            public string? AuthorFirstName { get; set; }
            public decimal Price { get; set; }
        }

    }
}
