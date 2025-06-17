using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        public readonly AppDbContext _dbContext;

        public PaymentMethodRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void Delete(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void Edit(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public bool Exist(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaymentMethod? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
