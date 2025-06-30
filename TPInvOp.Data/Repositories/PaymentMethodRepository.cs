using Microsoft.EntityFrameworkCore;
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
            _dbContext.PaymentMethods.Add(paymentMethod);
        }

        public void Remove(int paymentMethodId)
        {
            var paymentMethodInDb = GetById(paymentMethodId);
            if (paymentMethodInDb is not null)
            {
                _dbContext.Entry(paymentMethodInDb).State = EntityState.Deleted;
            }
        }

        public void Update(PaymentMethod paymentMethod)
        {
            var paymentMehodInDb = GetById(paymentMethod.PaymentMethodId);
            if (paymentMehodInDb != null)
            {
                paymentMehodInDb.Name = paymentMethod.Name;
                paymentMehodInDb.Description = paymentMethod.Description;
                paymentMehodInDb.IsActive = paymentMethod.IsActive;

                _dbContext.Entry(paymentMehodInDb).State = EntityState.Modified;
            }
        }

        public bool Exist(PaymentMethod paymentMethod, int? excludeId = null)
        {
            return excludeId.HasValue
               ? _dbContext.PaymentMethods.Any(p => p.Name.ToUpper() == paymentMethod.Name.ToUpper()
                               && p.PaymentMethodId != excludeId)
               : _dbContext.PaymentMethods.Any(p => p.Name.ToUpper() == paymentMethod.Name.ToUpper());
        }

        public IQueryable<PaymentMethod> GetAll()
        {
            return (IQueryable<PaymentMethod>)_dbContext.PaymentMethods.AsNoTracking();
        }

        public PaymentMethod? GetById(int id)
        {
            return _dbContext.PaymentMethods.AsNoTracking().FirstOrDefault(p => p.PaymentMethodId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
