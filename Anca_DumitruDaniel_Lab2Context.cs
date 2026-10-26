
using Microsoft.EntityFrameworkCore;

namespace Anca_DumitruDaniel_Lab2.Data;

public class Anca_DumitruDaniel_Lab2Context(
    DbContextOptions<Anca_DumitruDaniel_Lab2Context> options)
    : DbContext(options)
{
    public DbSet<Anca_DumitruDaniel_Lab2.Models.Book> Book
    { get; set; } = default!;

    public DbSet<Anca_DumitruDaniel_Lab2.Models.Publisher> Publisher
    { get; set; } = default!;

    public DbSet<Anca_DumitruDaniel_Lab2.Models.Category> Category
    { get; set; } = default!;

    public DbSet<Anca_DumitruDaniel_Lab2.Models.BookCategory> BookCategory
    { get; set; } = default!;
}
