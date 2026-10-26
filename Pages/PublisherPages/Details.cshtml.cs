using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_DumitruDaniel_Lab2.Models;
using Anca_DumitruDaniel_Lab2.Data;
namespace Anca_DumitruDaniel_Lab2.Pages.PublisherPages;

public class DetailsModel : PageModel
{
    private readonly Anca_DumitruDaniel_Lab2Context _context;
    public DetailsModel(Anca_DumitruDaniel_Lab2Context context)
    {
        _context = context;
    }

    public Publisher Publisher { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
        if (publisher is null)
        {
            return NotFound();
        }
        else
        {
            Publisher = publisher;
        }

        return Page();
    }
}
