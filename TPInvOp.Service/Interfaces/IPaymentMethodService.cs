using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.PaymentMethod;

namespace TPInvOp.Service.Interfaces
{
    public interface IPaymentMethodService
    {
        IEnumerable<PaymentMethodListDto> GetAll();
        bool Add (PaymentMethodEditDto paymentMethodDto, out List<string>errors);
        void Remove (int paymentMethodId);
        bool Exist(string name, int? excludeId=null);
        PaymentMethod PaymentMethodGetById(int paymentMethodId,bool tracked=false);
    }
}
