﻿using ApplicationDbContext;
using ApplicationDbContext.Migrations;
using BussinesObject;
using DeveloperAssessmentProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

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

    }
}
