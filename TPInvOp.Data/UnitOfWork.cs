using TPInvOp.Data.Interfaces;

namespace TPInvOp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext, ICategoryRepository categories)
        {
            _dbContext = dbContext;
            Categories = categories;
        }

        public ICategoryRepository Categories { get; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
    }
}
