
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Anca_DumitruDaniel_Lab2.Data;
using Anca_DumitruDaniel_Lab2.Models;

namespace Anca_DumitruDaniel_Lab2.Pages.BorrowingPages
{
    public class CreateModel : PageModel
    {
        private readonly Anca_DumitruDaniel_Lab2Context _context;

        public CreateModel(Anca_DumitruDaniel_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public IActionResult OnGet()
        {
            var bookList = _context.Book
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author
                });

            ViewData["BookID"] = new SelectList(
                bookList, "ID", "BookFullName");

            ViewData["MemberID"] = new SelectList(
                _context.Member, "ID", "FullName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var bookList = _context.Book
                    .Select(x => new
                    {
                        x.ID,
                        BookFullName = x.Title + " - " + x.Author
                    });

                ViewData["BookID"] = new SelectList(
                    bookList, "ID", "BookFullName");

                ViewData["MemberID"] = new SelectList(
                    _context.Member, "ID", "FullName");

                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
