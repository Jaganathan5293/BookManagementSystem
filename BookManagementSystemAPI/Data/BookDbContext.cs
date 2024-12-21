using BookManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.API.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
}
