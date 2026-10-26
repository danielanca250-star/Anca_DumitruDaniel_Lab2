
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_DumitruDaniel_Lab2.Models;
using Anca_DumitruDaniel_Lab2.Data;
namespace Anca_DumitruDaniel_Lab2.Pages.BookPages;

public class DetailsModel : PageModel
{
    private readonly Anca_DumitruDaniel_Lab2Context _context;

    public DetailsModel(Anca_DumitruDaniel_Lab2Context context)
    {
        _context = context;
    }

    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (book is null)
        {
            return NotFound();
        }

        Book = book;

        return Page();
    }
}
