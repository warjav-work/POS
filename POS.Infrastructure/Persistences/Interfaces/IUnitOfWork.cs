using POS.Infrastructure.FileStorage;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Declaración o matricula de interfaces a niver repository
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IAzureStorage Storage { get; }
        IProviderRepository Provider { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
