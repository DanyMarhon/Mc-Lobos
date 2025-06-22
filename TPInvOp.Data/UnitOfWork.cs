using TPInvOp.Data.Interfaces;

namespace TPInvOp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext, ICategoryRepository categories, ILocalityRepository localities)
        {
            _dbContext = dbContext;
            Categories = categories;
            Localities = localities;
        }

        public ICategoryRepository Categories { get; }

        public ILocalityRepository Localities { get; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
    }
}
