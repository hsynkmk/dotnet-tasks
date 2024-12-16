using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Web.Views.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Book>? Books { get; set; }
        public decimal Price { get; set; }
    }
}
