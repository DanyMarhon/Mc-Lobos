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
        private IProductRepository _product;
        private ICustomerRepository _customer;
        private EmployeeRepository _employee;
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

        public ICustomerRepository Customer
        { get { _customer ??= new CustomerRepository(_dbContext); return _customer; } }
        public IProductRepository Products
        { get { _product ??= new ProductRepository(_dbContext); return _product; } }
        public IEmployeeRepository Employee
        { get { _employee ??= new EmployeeRepository(_dbContext); return _employee; } }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
    }
}
