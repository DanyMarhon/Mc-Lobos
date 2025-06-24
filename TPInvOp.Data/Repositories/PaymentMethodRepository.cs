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

        public void Delete(int paymentMethodId)
        {
            var paymentMethodInDb = GetById(paymentMethodId, true);
            if (paymentMethodInDb != null)
            {
                _dbContext.PaymentMethods.Remove(paymentMethodInDb);
            }
        }

        public void Edit(PaymentMethod paymentMethod)
        {
            var paymentMethodInDb = GetById(paymentMethod.PaymentMethodID, true);
            if (paymentMethodInDb != null)
            {
                paymentMethodInDb.Name = paymentMethod.Name;
                paymentMethodInDb.Description = paymentMethod.Description;
            }
        }

        public bool Exist(string name, int? excludeId = null)
        {
            return excludeId.HasValue
               ? _dbContext.PaymentMethods.Any(p => p.Name.ToUpper() == name.ToUpper()
                               && p.PaymentMethodID != excludeId)
               : _dbContext.PaymentMethods.Any(p => p.Name.ToUpper() == name.ToUpper());
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            return _dbContext.PaymentMethods.ToList();
        }

        public PaymentMethod? GetById(int id, bool tracked = false)
        {
            return tracked
                 ? _dbContext.PaymentMethods.FirstOrDefault(p => p.PaymentMethodID == id)
                 : _dbContext.PaymentMethods.AsNoTracking().FirstOrDefault(p => p.PaymentMethodID == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
