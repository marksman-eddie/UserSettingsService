using UserManagment.Core.Contracts;

namespace UserManagment.Data
{   
    public class AppUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ILayoutRepository LayoutRepository { get; set; }

        public AppUnitOfWork(ApplicationDbContext context,
            ILayoutRepository layoutRepository)
        {
            _context = context;
            LayoutRepository = layoutRepository;
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
