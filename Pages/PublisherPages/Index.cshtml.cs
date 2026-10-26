
using Anca_DumitruDaniel_Lab2.Data;
using Anca_DumitruDaniel_Lab2.Models;
using Anca_DumitruDaniel_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Anca_DumitruDaniel_Lab2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Anca_DumitruDaniel_Lab2Context _context;

    public IndexModel(Anca_DumitruDaniel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public PublisherIndexData PublisherData { get; set; }
        = new PublisherIndexData();

    public int PublisherID { get; set; }

    public int BookID { get; set; }

    public async Task OnGetAsync(int? id, int? bookID)
    {
        PublisherData = new PublisherIndexData();

        PublisherData.Publishers = await _context.Publisher
            .Include(p => p.Books)
            .OrderBy(p => p.PublisherName)
            .ToListAsync();

        if (id != null)
        {
            PublisherID = id.Value;

            Publisher publisher = PublisherData.Publishers
                .Single(p => p.ID == id.Value);

            PublisherData.Books = publisher.Books;
        }
    }
}
