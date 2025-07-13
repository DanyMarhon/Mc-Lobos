using TPInvOp.Data.Interfaces;

namespace TPInvOp.Data
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ILocalityRepository Localities { get; }
        IPaymentMethodRepository PaymentMethod { get; }
        ICustomerRepository Customer { get; }
        IProductRepository Products { get; }
        IEmployeeRepository Employee { get; }
        int Complete();
    }
}
