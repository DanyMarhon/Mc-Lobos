using TPInvOp.Data.Interfaces;
using TPInvOp.Data.Repositories;

namespace TPInvOp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private ICategoryRepository _categories;
        private ILocalityRepository _localities;
        private IPaymentMethodRepository _paymentMethod;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository Categories
        { get { _categories ??= new CategoryRepository(_dbContext); return _categories; } }


        public ILocalityRepository Localities
        { get { _localities ??= new LocalityRepository(_dbContext); return _localities; } }

        public IPaymentMethodRepository PaymentMethod
        { get { _paymentMethod ??= new PaymentMethodRepository(_dbContext); return _paymentMethod; } }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
    }
}
