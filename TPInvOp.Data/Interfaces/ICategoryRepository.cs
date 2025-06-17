using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        void Add(Category category);
        bool Exist(Category category);
        void Edit(Category category);
        void Delete(Category category);
    }
}
