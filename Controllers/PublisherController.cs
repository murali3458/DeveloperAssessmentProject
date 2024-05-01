using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private static List<book> _books = new List<book> {

              new book { publisher="SriRam", Title="DrawingIsHeartOfList",AuthorLastName="Krishna", AuthorFirstName="murali",Price="499"},
              new book { publisher="Arivu", Title="BestCourseInAfterPlusTwo",AuthorLastName="L", AuthorFirstName="Arivu",Price="99"}

        };

        [HttpGet]
        public IActionResult getPublisherList()
        {
            var result = _books.OrderBy(o => o.publisher)
                                .ThenBy(o => o.AuthorLastName)
                                .ThenBy(o => o.AuthorFirstName)
                                .ThenBy(o => o.Title)
                                .ToList();

            return Ok(result);
        }

        public class book
        {
            public string? publisher { get; set; }
            public string? Title { get; set; }
            public string? AuthorLastName { get; set; }
            public string? AuthorFirstName { get; set; }
            public string? Price { get; set; }
        }
    }
}
