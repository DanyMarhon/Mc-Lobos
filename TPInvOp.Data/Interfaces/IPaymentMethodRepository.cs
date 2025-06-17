using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<PaymentMethod> GetAll();
        PaymentMethod? GetById(int id);
        void Add(PaymentMethod paymentMethod);
        bool Exist(PaymentMethod paymentMethod);
        void Edit(PaymentMethod paymentMethod);
        void Delete(PaymentMethod paymentMethod);
    }
}
