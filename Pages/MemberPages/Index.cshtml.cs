using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_DumitruDaniel_Lab2.Data;

namespace Anca_DumitruDaniel_Lab2.Pages.MemberPages;

public class IndexModel : PageModel
{
    private readonly Anca_DumitruDaniel_Lab2Context _context;

    public IndexModel(Anca_DumitruDaniel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Member> Member { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Member = await _context.Member.ToListAsync();
    }
}
