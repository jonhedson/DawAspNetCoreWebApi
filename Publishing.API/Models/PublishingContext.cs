using Microsoft.EntityFrameworkCore;

namespace Publishing.API.Models
{
    public class PublishingContext : DbContext
    {

        public PublishingContext()
        {

        }

        public PublishingContext(DbContextOptions<PublishingContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> AuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(t => new { t.AuthorId, t.BookId });

            modelBuilder.Entity<BookAuthor>()
                        .HasOne(t => t.Author)
                        .WithMany(t => t.BookAuthor)
                        .HasForeignKey(t => t.BookId);

            modelBuilder.Entity<BookAuthor>()
                        .HasOne(t => t.Author)
                        .WithMany(t => t.BookAuthor)
                        .HasForeignKey(t => t.AuthorId);
        }

    }
}
