using TPInvOp.Model.Entities;

namespace TPInvOp.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }
}

