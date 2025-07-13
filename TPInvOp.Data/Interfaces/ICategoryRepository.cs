using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        bool Exist(Category category, int? excludeId = null);
        void Update(Category category);
    }
}
