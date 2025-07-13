using Microsoft.EntityFrameworkCore;
using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Exist(Customer Customer, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Customers.Any(c => c.CustomerName.ToUpper() == Customer.CustomerName.ToUpper()
                                && c.CustomerID != excludeId)
                : _dbContext.Customers.Any(c => c.CustomerName.ToUpper() == Customer.CustomerName.ToUpper());
        }
        public void Update(Customer Customer)
        {
            var CustomerInDb = Get(filter: c => c.CustomerID == Customer.CustomerID,
                tracked: true);
            if (CustomerInDb != null)
            {
                CustomerInDb.CustomerName = Customer.CustomerName;
                CustomerInDb.DeliveryAddress = Customer.DeliveryAddress;
                CustomerInDb.ContactPhone = Customer.ContactPhone;
                CustomerInDb.LocalityID = Customer.LocalityID;

                _dbContext.Entry(CustomerInDb).State = EntityState.Modified;
            }
        }
    }
}
