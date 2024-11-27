using Microsoft.EntityFrameworkCore;
using BookDonorsAPI.Models;

namespace BookDonorsAPI.Data
{
    public class BookDonationContext : DbContext
    {
        public BookDonationContext(DbContextOptions<BookDonationContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Donor> Donors { get; set; }
    }
}