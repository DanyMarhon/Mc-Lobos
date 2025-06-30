using Microsoft.EntityFrameworkCore;
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
            _dbContext.Categories.Add(category);
        }

        public void Remove(int categoryId)
        {
            var categoryInDb = GetById(categoryId);
            if (categoryInDb is not null)
            {
                _dbContext.Entry(categoryInDb).State = EntityState.Deleted;
            }
        }

        public void Update(Category category)
        {
            var categoryInDb = GetById(category.CategoryId);
            if (categoryInDb != null)
            {
                categoryInDb.CategoryName = category.CategoryName;
                categoryInDb.Description = category.Description;
                categoryInDb.IsActive = category.IsActive;

                _dbContext.Entry(categoryInDb).State = EntityState.Modified;
            }
        }

        public bool Exist(Category category, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Categories
                            .Any(c => c.CategoryName.ToUpper() == category.CategoryName.ToUpper()
                                && c.CategoryId != excludeId)
                : _dbContext.Categories
                            .Any(c => c.CategoryName.ToUpper() == category.CategoryName.ToUpper());
        }

        public IQueryable<Category> GetAll()
        {
            return (IQueryable<Category>)_dbContext.Categories.AsNoTracking();
        }

        public Category? GetById(int id)
        {
            return _dbContext.Categories.AsNoTracking().FirstOrDefault(c => c.CategoryId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
