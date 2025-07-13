using Microsoft.EntityFrameworkCore;
using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
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

        public void Update(Category category)
        {
            var categoryInDb = Get(filter:c => c.CategoryId == category.CategoryId,
                tracked: true);
            if (categoryInDb != null)
            {
                categoryInDb.CategoryName = category.CategoryName;
                categoryInDb.Description = category.Description;
                categoryInDb.IsActive = category.IsActive;
            }
        }
    }
}
