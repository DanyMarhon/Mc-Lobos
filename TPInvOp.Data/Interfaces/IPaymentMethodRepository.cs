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
        PaymentMethod? GetById(int id, bool tracked = false);
        void Add(PaymentMethod paymentMethod);
        bool Exist(string name, int? excludeId = null);
        void Edit(PaymentMethod paymentMethod);
        void Delete(int paymentMethodId);
        void SaveChanges();
    }
}

