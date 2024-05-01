using ApplicationDbContext;
using ApplicationDbContext.Migrations;
using BussinesObject;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssessmentProject.Repository
{
    public class BookRepository
    {
        private readonly AppDbContext  _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BooksModel>> GetBooksFromStoredProcedureAsync()
        {

            var b = await  _context.Books.FromSqlRaw("EXEC PublisherwiseProcedure").ToListAsync();

            return b;
        }

      
    }
}
