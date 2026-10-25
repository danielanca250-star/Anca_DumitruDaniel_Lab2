
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Anca_DumitruDaniel_Lab2.Models;

namespace Anca_DumitruDaniel_Lab2.Pages.BookPages;

public class CreateModel : BookCategoriesPageModel
{
    private readonly Anca_DumitruDaniel_Lab2Context _context;

    public CreateModel(Anca_DumitruDaniel_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public IActionResult OnGet()
    {
        Book = new Book();
        Book.BookCategories = new List<BookCategory>();

        PopulateAssignedCategoryData(_context, Book);

        ViewData["PublisherID"] = new SelectList(
            _context.Set<Publisher>(), "ID", "PublisherName");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        if (!ModelState.IsValid)
        {
            PopulateAssignedCategoryData(_context, Book);

            ViewData["PublisherID"] = new SelectList(
                _context.Set<Publisher>(), "ID", "PublisherName");

            return Page();
        }

        Book.BookCategories = new List<BookCategory>();

        UpdateBookCategories(_context, selectedCategories, Book);

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
