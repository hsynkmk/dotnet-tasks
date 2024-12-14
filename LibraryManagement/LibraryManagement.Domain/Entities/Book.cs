namespace LibraryManagement.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int PublicationYear { get; set; }
        public required string ISBN { get; set; }
        public required string Genre { get; set; }
        public required string Publisher { get; set; }
        public required int PageCount { get; set; }
        public required string Language { get; set; }
        public string? Summary { get; set; }
        public int AvailableCopies { get; set; }
    }
}
