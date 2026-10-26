
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_DumitruDaniel_Lab2.Models;
using Anca_DumitruDaniel_Lab2.Data;

namespace Anca_DumitruDaniel_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Anca_DumitruDaniel_Lab2Context _context;

    public IndexModel(Anca_DumitruDaniel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public IList<Book> Books { get; set; } = new List<Book>();

    public int? CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        Category = await _context.Category
            .OrderBy(c => c.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;

            _context.BookCategory
                 .Where(bc => bc.CategoryID == id.Value)
                .Select(bc => bc.Book!)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
