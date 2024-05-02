using ApplicationDbContext;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssessmentProject.Controllers
{
    public class CMSStyleController : Controller
    {
        private readonly AppDbContext _Context;

        public CMSStyleController(AppDbContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var books = _Context.Books;
            var list = _Context.Books.ToList();

            return View(list);
        }
    }
}
