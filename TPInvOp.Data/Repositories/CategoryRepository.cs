using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public void Edit(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
