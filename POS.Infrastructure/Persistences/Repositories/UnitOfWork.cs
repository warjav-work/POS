using Microsoft.Extensions.Configuration;
using POS.Infrastructure.FileStorage;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly POSContext _context;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IAzureStorage Storage { get; private set; }
        public IProviderRepository Provider { get; private set; }

        public UnitOfWork(POSContext context, IConfiguration configuration)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            UserRepository = new UserRepository(_context);
            Storage = new AzureStorage(configuration);
            Provider = new ProviderRepository(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
