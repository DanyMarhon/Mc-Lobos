using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        bool Exist(Customer customer, int? excludeId = null);
        void Update(Customer customer);
    }
}
