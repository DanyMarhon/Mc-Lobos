using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.PaymentMethod;

namespace TPInvOp.Service.Interfaces
{
    public interface IPaymentMethodService
    {
        IQueryable<PaymentMethodListDto> GetAll();
        PaymentMethodEditDto? PaymentMethodById(int id);
        bool Exist(PaymentMethod paymentMethod, int? excludeId = null);
        bool Save(PaymentMethodEditDto paymentMethodDto, out List<string> errors);
        bool Remove(int paymentMethodId, out List<string> errors);
    }
}
