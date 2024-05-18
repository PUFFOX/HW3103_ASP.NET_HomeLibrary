using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using HW3103.Models;

namespace HW3103.Pages
{
    public class BooksModel : PageModel
    {
        private readonly BookService _bookService;

        public BooksModel(BookService bookService)
        {
            _bookService = bookService;
        }

        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = _bookService.GetBooks();
        }
    }
}
