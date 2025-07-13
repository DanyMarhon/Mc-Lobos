using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Product;
using TPInvOp.Service.Interfaces;

namespace TPInvOp.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IQueryable<ProductListDto> GetAll()
        {
            var productes = _unitOfWork.Products.GetAll();
            return _mapper.ProjectTo<ProductListDto>(productes);
        }

        public ProductEditDto? ProductById(int id)
        {
            var product = _unitOfWork.Products.Get(filter: p => p.ProductID == id,
                tracked: true);
            if (product is null) return null;
            return _mapper.Map<ProductEditDto>(product);
        }

        public bool Exist(Product product, int? excludeId = null)
        {
            return _unitOfWork.Products.Exist(product, excludeId);
        }

        public bool Save(ProductEditDto productDto, out List<string> errors)
        {
            errors = new List<string>();
            Product product = _mapper.Map<Product>(productDto);
            if (product.ProductID == 0)
            {
                if (!_unitOfWork.Products.Exist(product))
                {
                    _unitOfWork.Products.Add(product);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Product Already Exist!!");
                    return false;
                }

            }
            else
            {
                if (!_unitOfWork.Products.Exist(product, product.ProductID))
                {
                    _unitOfWork.Products.Update(product);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Product Already Exist!!");
                    return false;
                }

            }
        }

        public bool Remove(int productId, out List<string> errors)
        {
            errors = new List<string>();
            var product = _unitOfWork.Products.Get(filter: l => l.ProductID == productId,
                tracked: true);
            if (product is null)
            {
                errors.Add("Product does not exist");
                return false;
            }
            _unitOfWork.Products.Remove(product);
            var rowsAffected = _unitOfWork.Complete();
            return rowsAffected > 0;
        }
    }
}
