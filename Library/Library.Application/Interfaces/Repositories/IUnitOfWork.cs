namespace Library.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        Task<int> SaveChangesAsync();
    }
}
