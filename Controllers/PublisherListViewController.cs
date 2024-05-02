using ApplicationDbContext;
using ApplicationDbContext.Migrations;
using Microsoft.AspNetCore.Mvc;
using BussinesObject;
using System.Security.Cryptography.Xml;
using System.Net;

namespace DeveloperAssessmentProject.Controllers
{
    public class PublisherListViewController : Controller
    {

        private readonly AppDbContext _context;

        public PublisherListViewController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult getBook(int BookId)
        {
            var res = _context.Books.Where(a => a.BooksId == BookId).FirstOrDefault();
            return Json(res);
        }


        public IActionResult Detail(int Id)
        {
            var res = _context.Books.Where(a => a.BooksId == Id).FirstOrDefault();

            BooksModel model = new BooksModel();

            model.BooksId = res!.BooksId;
            model.Publisher = res.Publisher;
            model.Title = res.Title;
            model.AuthorLastName = res.AuthorLastName;
            model.AuthorFirstName = res.AuthorFirstName;
            model.Price = res.Price;
            return View(model);
        }

        [HttpPost]
        public IActionResult DetailRemove(int BookId)
        {
            bool result = false;

            var res = _context.Books.Where(a => a.BooksId == BookId).FirstOrDefault();

            if (res != null)
            {
                _context.Books.Remove(res);
                _context.SaveChanges();
                result = true;
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult create(BussinesObject.BooksModel bm)
        {

            if (bm.BooksId <= 0)
                _context.Books.Add(bm);
            else
                _context.Books.Update(bm);

            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
