using Microsoft.EntityFrameworkCore;
using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public readonly AppDbContext _dbContext;

        public PaymentMethodRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Exist(PaymentMethod paymentMethod, int? excludeId = null)
        {
            return excludeId.HasValue
               ? _dbContext.PaymentMethods.Any(p => p.Name.ToUpper() == paymentMethod.Name.ToUpper()
                               && p.PaymentMethodId != excludeId)
               : _dbContext.PaymentMethods.Any(p => p.Name.ToUpper() == paymentMethod.Name.ToUpper());
        }
        public void Update(PaymentMethod paymentMethod)
        {
            var paymentMehodInDb = Get(filter: p => p.PaymentMethodId == paymentMethod.PaymentMethodId,
                tracked: true);
            if (paymentMehodInDb != null)
            {
                paymentMehodInDb.Name = paymentMethod.Name;
                paymentMehodInDb.Description = paymentMethod.Description;
                paymentMehodInDb.IsActive = paymentMethod.IsActive;

                _dbContext.Entry(paymentMehodInDb).State = EntityState.Modified;
            }
        }
    }
}
