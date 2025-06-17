using TPInvOp.Model.Entities;

namespace TPInvOp.Service.Interfaces
{
    public interface IPaymentMethodService
    {
        IEnumerable<PaymentMethod> GetAll();
    }
}
