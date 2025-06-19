using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll(string? sortedBy = null);
        Category? GetById(int id, bool tracked = false);
        void Add(Category category);
        bool Exist(string name, int? excludeId = null);
        void Edit(Category category);
        void Delete(int categoryId);
        void SaveChanges();
    }
}
