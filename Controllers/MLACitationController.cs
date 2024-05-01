using ApplicationDbContext;
using BussinesObject;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssessmentProject.Controllers
{
    public class MLACitationController : Controller
    {
        private readonly AppDbContext _context;

        public MLACitationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BooksModel model = new BooksModel();            
            var list = _context.Books.ToList();

            return View(list);
        }
    }
}
