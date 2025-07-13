using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        bool Exist(Product product, int? excludeId = null);
        void Update(Product product);
    }
}

