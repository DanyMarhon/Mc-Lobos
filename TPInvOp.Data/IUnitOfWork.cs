using TPInvOp.Data.Interfaces;

namespace TPInvOp.Data
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
