namespace UserManagment.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ILayoutRepository LayoutRepository { get; set; }
        Task SaveChangesAsync();
    }
}
