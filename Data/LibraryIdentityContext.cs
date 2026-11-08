using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options) : IdentityDbContext<Anca_DumitruDaniel_Lab2.Data.ApplicationUser>(options)
{
}
