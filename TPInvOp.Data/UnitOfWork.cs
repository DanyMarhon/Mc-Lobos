using TPInvOp.Data.Interfaces;

namespace TPInvOp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext, ICategoryRepository categories, ILocalityRepository localities, IPaymentMethodRepository paymentMethod)
        {
            _dbContext = dbContext;
            Categories = categories;
            Localities = localities;
            PaymentMethod = paymentMethod;
        }

        public ICategoryRepository Categories { get; }

        public ILocalityRepository Localities { get; }

        public IPaymentMethodRepository PaymentMethod { get; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
    }
}
