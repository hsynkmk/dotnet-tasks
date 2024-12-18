using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SEEDDATA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "Genre", "ISBN", "Language", "PageCount", "PublicationYear", "Publisher", "Summary", "Title" },
                values: new object[,]
                {
                    { new Guid("2639e78c-12d7-4337-9d9f-1ac7b90d1177"), "Jane Austen", 4, "Fiction", "9780141439518", "English", 279, 1813, "Penguin Classics", "Pride and Prejudice is a romantic novel of manners written by Jane Austen in 1813. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.", "Pride and Prejudice" },
                    { new Guid("a2a57b25-56ad-4481-9bdc-244bac2ad32b"), "F. Scott Fitzgerald", 5, "Fiction", "9780743273565", "English", 180, 1925, "Scribner", "The Great Gatsby is a novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, near New York City, the novel depicts first-person narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.", "The Great Gatsby" },
                    { new Guid("d1b81886-68ba-4300-949b-32650f18a7f0"), "Harper Lee", 3, "Fiction", "9780060935467", "English", 281, 1960, "Harper Perennial Modern Classics", "To Kill a Mockingbird is a novel by Harper Lee published in 1960. Instantly successful, widely read in high schools and middle schools in the United States, it has become a classic of modern American literature, winning the Pulitzer Prize.", "To Kill a Mockingbird" },
                    { new Guid("eb0b3ad7-b456-4974-9b3d-b965ddc1b549"), "George Orwell", 2, "Fiction", "9780451524935", "English", 328, 1949, "Signet Classic", "1984 is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.", "1984" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2639e78c-12d7-4337-9d9f-1ac7b90d1177"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a2a57b25-56ad-4481-9bdc-244bac2ad32b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d1b81886-68ba-4300-949b-32650f18a7f0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("eb0b3ad7-b456-4974-9b3d-b965ddc1b549"));
        }
    }
}
