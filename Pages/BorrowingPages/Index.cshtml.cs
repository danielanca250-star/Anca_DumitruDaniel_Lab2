
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_DumitruDaniel_Lab2.Data;
using Anca_DumitruDaniel_Lab2.Models;

namespace Anca_DumitruDaniel_Lab2.Pages.BorrowingPages
{
    public class IndexModel : PageModel
    {
        private readonly Anca_DumitruDaniel_Lab2Context _context;

        public IndexModel(Anca_DumitruDaniel_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .Include(b => b.Member)
                .ToListAsync();
        }
    }
}
