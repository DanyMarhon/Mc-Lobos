using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category? GetById(int id);
        void Add(Category category);
        bool Exist(Category category, int? excludeId = null);
        void Update(Category category);
        void Remove(int categoryId);
        void SaveChanges();
    }
}
