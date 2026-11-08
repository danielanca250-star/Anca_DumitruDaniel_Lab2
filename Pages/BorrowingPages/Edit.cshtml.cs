
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anca_DumitruDaniel_Lab2.Data;
using Anca_DumitruDaniel_Lab2.Models;

namespace Anca_DumitruDaniel_Lab2.Pages.BorrowingPages
{
    public class EditModel : PageModel
    {
        private readonly Anca_DumitruDaniel_Lab2Context _context;

        public EditModel(Anca_DumitruDaniel_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        private void PopulateLists()
        {
            var bookList = _context.Book
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author
                })
                .ToList();

            ViewData["BookID"] = new SelectList(
                bookList, "ID", "BookFullName", Borrowing?.BookID);

            ViewData["MemberID"] = new SelectList(
                _context.Member.ToList(),
                "ID",
                "FullName",
                Borrowing?.MemberID);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            PopulateLists();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateLists();
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
