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

        public void Delete(int categoryId)
        {
            var categoryInDb = GetById(categoryId, true);
            if (categoryInDb != null)
            {
                _dbContext.Categories.Remove(categoryInDb);
            }
        }

        public void Edit(Category category)
        {
            var categoryInDb = GetById(category.CategoryId, true);
            if (categoryInDb != null)
            {
                categoryInDb.CategoryName = category.CategoryName;
                categoryInDb.Description = category.Description;
            }
        }

        public bool Exist(string name, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Categories
                            .Any(c => c.CategoryName.ToUpper() == name.ToUpper() 
                                && c.CategoryId != excludeId)
                : _dbContext.Categories
                            .Any(c => c.CategoryName.ToUpper() == name.ToUpper());
        }

        public IEnumerable<Category> GetAll(string? sortedBy = null)
        {
            IQueryable<Category> query = _dbContext.Categories
                .AsNoTracking();
            switch (sortedBy?.ToLower())
            {
                case "name":
                    return query.OrderBy(c => c.CategoryName).ToList();
                case "longitud":
                    return query.OrderBy(c => c.CategoryName.Length).ToList();
                default:
                    return query.OrderBy(c => c.CategoryId).ToList();
            }
        }

        public Category? GetById(int id, bool tracked)
        {
            return tracked
                ? _dbContext.Categories
                            .FirstOrDefault(c => c.CategoryId == id)
                : _dbContext.Categories.AsNoTracking()
                            .FirstOrDefault(c => c.CategoryId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
