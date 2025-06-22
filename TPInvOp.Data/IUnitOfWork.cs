using TPInvOp.Data.Interfaces;

namespace TPInvOp.Data
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ILocalityRepository Localities { get; }

        int Complete();
    }
}
