using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        bool Exist(Customer customer, int? excludeId = null);
        void Update(Customer customer);
    }
}
