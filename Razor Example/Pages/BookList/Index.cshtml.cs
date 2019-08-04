using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jasarsoft.Razor.Example.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Example.Model;

namespace Razor_Example.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }
    }
}