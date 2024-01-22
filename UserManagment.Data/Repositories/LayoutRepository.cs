using Microsoft.EntityFrameworkCore;
using UserManagment.Core.Contracts;
using UserManagment.Core.Entities;

namespace UserManagment.Data.Repositories
{
    public class LayoutRepository
        : ILayoutRepository
    {
        private readonly ApplicationDbContext db;
        public LayoutRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        void IDisposable.Dispose() => db.Dispose();
        
        public async Task<Layout?> GetAsync(string userLogin, string interfaceType)
        {
            var query = db.Layouts
                .Where(x => x.UserLogin == userLogin)
                .Where(x => x.InterfaceType == interfaceType)
                .AsNoTracking();
            var entity = await query.FirstOrDefaultAsync();
            if (entity is null)
                return null;
            return entity;
        }
        public async Task<Layout> GetOrDefaultAsync(string userLogin, string interfaceType)
        {
            var entity = await GetAsync(userLogin,interfaceType);
            if (entity is null)
                return new Layout();
            return entity;
        }
        
        public async Task<int> CreateAsync(Layout entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            var entry = db.Layouts.Add(entity);
            await db.SaveChangesAsync();
            entry.State = EntityState.Detached;
            return ILayoutRepository.ResultCode;
        }

        public async Task<int> UpdateAsync(Layout entity)
        {
            if (entity.UserLogin is null)
                throw new ArgumentNullException($"{nameof(entity.UserLogin)} is null");
            if (entity.InterfaceType is null)
                throw new ArgumentNullException($"{nameof(entity.InterfaceType)} is null");
            var existingEntity = await GetAsync(entity.UserLogin, entity.InterfaceType);
            if (existingEntity is null)
                return ILayoutRepository.ErrorNotFound;
            var entry = db.Update(entity);
            await db.SaveChangesAsync();
            entry.State = EntityState.Detached;
            return ILayoutRepository.ResultCode;
        }
    }
}
