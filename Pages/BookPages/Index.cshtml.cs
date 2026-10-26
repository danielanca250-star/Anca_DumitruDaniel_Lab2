
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_DumitruDaniel_Lab2.Models;
using Anca_DumitruDaniel_Lab2.Data;

namespace Anca_DumitruDaniel_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Anca_DumitruDaniel_Lab2Context _context;

    public IndexModel(Anca_DumitruDaniel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public string TitleSort { get; set; } = "";
    public string AuthorSort { get; set; } = "";
    public string? CurrentFilter { get; set; }

    public async Task OnGetAsync(
        string? sortOrder,
        string? searchString)
    {
        TitleSort = string.IsNullOrEmpty(sortOrder)
            ? "title_desc"
            : "";

        AuthorSort = sortOrder == "author"
            ? "author_desc"
            : "author";

        CurrentFilter = searchString;

        var books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
            .AsNoTracking()
            .ToListAsync();

        // Cautare dupa titlu sau autor
        if (!string.IsNullOrWhiteSpace(searchString))
        {
            books = books
                .Where(b =>
                    (!string.IsNullOrEmpty(b.Title) &&
                     b.Title.Contains(
                         searchString,
                         StringComparison.OrdinalIgnoreCase))
                    ||
                    (!string.IsNullOrEmpty(b.Author) &&
                     b.Author.Contains(
                         searchString,
                         StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // Sortare dupa titlu sau autor
        switch (sortOrder)
        {
            case "title_desc":
                books = books
                    .OrderByDescending(b => b.Title)
                    .ToList();
                break;

            case "author":
                books = books
                    .OrderBy(b => b.Author)
                    .ToList();
                break;

            case "author_desc":
                books = books
                    .OrderByDescending(b => b.Author)
                    .ToList();
                break;

            default:
                books = books
                    .OrderBy(b => b.Title)
                    .ToList();
                break;
        }

        Book = books;
    }
}
