using Microsoft.EntityFrameworkCore;
using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Exist(Product product, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Products.Any(p => p.ProductName.ToUpper() == product.ProductName.ToUpper()
                                && p.ProductID != excludeId)
                : _dbContext.Products.Any(p => p.ProductName.ToUpper() == product.ProductName.ToUpper());
        }
        public void Update(Product product)
        {
            var productInDb = Get(filter: p => p.ProductID == product.ProductID,
                tracked: true);
            if (productInDb != null)
            {
                productInDb.ProductName = product.ProductName;
                productInDb.Price = product.Price;
                productInDb.Description = product.Description;
                productInDb.IsActive = product.IsActive;

                _dbContext.Entry(productInDb).State = EntityState.Modified;
            }
        }
    }
}
