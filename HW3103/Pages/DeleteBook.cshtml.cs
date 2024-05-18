using HW3103.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW3103.Pages
{
    public class DeleteBookModel : PageModel
    {
        private readonly BookService _bookService;

        public DeleteBookModel(BookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet(int id)
        {
            Book = _bookService.GetBookById(id);
        }

        public IActionResult OnPost(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToPage("Books");
        }
    }
}
