using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface IPaymentMethodRepository
    {
        IQueryable<PaymentMethod> GetAll();
        PaymentMethod? GetById(int id);
        void Add(PaymentMethod paymentMethod);
        bool Exist(PaymentMethod paymentMethod, int? excludeId = null);
        void Update(PaymentMethod paymentMethod);
        void Remove(int paymentMethodId);
        void SaveChanges();
    }
}

