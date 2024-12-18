namespace LibraryManagement.Application.Common.Constants
{
    public class Messages
    {
        // Success Messages
        public const string BookCreated = "The book has been created successfully.";
        public const string BookUpdated = "The book has been updated successfully.";

        // Error Messages
        public const string BookNotFound = "The requested book was not found.";
        public const string UserUnauthorized = "You are not authorized to perform this action.";

        // Validation Messages
        public const string InvalidISBN = "The provided ISBN is invalid.";
        public const string RequiredField = "This field is required.";
    }
}
