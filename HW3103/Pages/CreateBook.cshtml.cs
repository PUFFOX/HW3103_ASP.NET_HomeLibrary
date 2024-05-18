using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HW3103.Models;

namespace HW3103.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly BookService _bookService;

        public CreateBookModel(BookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookService.AddBook(Book);
            return RedirectToPage("Books");
        }
    }
}
