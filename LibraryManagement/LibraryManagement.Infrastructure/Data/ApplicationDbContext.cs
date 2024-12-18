using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = new Guid("a2a57b25-56ad-4481-9bdc-244bac2ad32b"),
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    PublicationYear = 1925,
                    ISBN = "9780743273565",
                    Genre = "Fiction",
                    Publisher = "Scribner",
                    PageCount = 180,
                    Language = "English",
                    Summary = "The Great Gatsby is a novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, near New York City, the novel depicts first-person narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.",
                    AvailableCopies = 5
                },
                new Book
                {
                    Id = new Guid("d1b81886-68ba-4300-949b-32650f18a7f0"),
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    PublicationYear = 1960,
                    ISBN = "9780060935467",
                    Genre = "Fiction",
                    Publisher = "Harper Perennial Modern Classics",
                    PageCount = 281,
                    Language = "English",
                    Summary = "To Kill a Mockingbird is a novel by Harper Lee published in 1960. Instantly successful, widely read in high schools and middle schools in the United States, it has become a classic of modern American literature, winning the Pulitzer Prize.",
                    AvailableCopies = 3
                },
                new Book
                {
                    Id = new Guid("eb0b3ad7-b456-4974-9b3d-b965ddc1b549"),
                    Title = "1984",
                    Author = "George Orwell",
                    PublicationYear = 1949,
                    ISBN = "9780451524935",
                    Genre = "Fiction",
                    Publisher = "Signet Classic",
                    PageCount = 328,
                    Language = "English",
                    Summary = "1984 is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.",
                    AvailableCopies = 2
                },
                new Book
                {
                    Id = new Guid("2639e78c-12d7-4337-9d9f-1ac7b90d1177"),
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    PublicationYear = 1813,
                    ISBN = "9780141439518",
                    Genre = "Fiction",
                    Publisher = "Penguin Classics",
                    PageCount = 279,
                    Language = "English",
                    Summary = "Pride and Prejudice is a romantic novel of manners written by Jane Austen in 1813. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.",
                    AvailableCopies = 4
                }
            );
        }
    }       
}
