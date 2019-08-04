﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jasarsoft.Razor.Example.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Example.Model;

namespace Razor_Example.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet(int id)
        {
            Book = db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = db.Books.Find(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await db.SaveChangesAsync();
                Message = "Book has been update sucessfully";

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}