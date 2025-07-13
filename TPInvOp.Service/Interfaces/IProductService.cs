using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Product;

namespace TPInvOp.Service.Interfaces
{
    public interface IProductService
    {
        IQueryable<ProductListDto> GetAll();
        ProductEditDto? ProductById(int id);
        bool Exist(Product product, int? excludeId = null);
        bool Save(ProductEditDto productDto, out List<string> errors);
        bool Remove(int productId, out List<string> errors);
    }
}
