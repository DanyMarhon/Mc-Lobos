using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface IPaymentMethodRepository : IGenericRepository<PaymentMethod>
    {
        bool Exist(PaymentMethod paymentMethod, int? excludeId = null);
        void Update(PaymentMethod paymentMethod);
    }
}

