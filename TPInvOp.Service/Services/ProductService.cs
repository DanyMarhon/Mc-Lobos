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
            var products = _unitOfWork.Products.GetAll();
            return _mapper.ProjectTo<ProductListDto>(products);
        }

        public ProductEditDto? ProductById(int id)
        {
            var category = _unitOfWork.Products.Get(filter: c => c.ProductId == id,
                tracked: true);
            if (category is null) return null;
            return _mapper.Map<ProductEditDto>(category);
        }

        public bool Exist(Product category, int? excludeId = null)
        {
            return _unitOfWork.Products.Exist(category, excludeId);
        }

        public bool Save(ProductEditDto categoryDto, out List<string> errors)
        {
            errors = new List<string>();
            Product category = _mapper.Map<Product>(categoryDto);
            if (category.ProductId == 0)
            {
                if (!_unitOfWork.Products.Exist(category))
                {
                    _unitOfWork.Products.Add(category);
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
                if (!_unitOfWork.Products.Exist(category, category.ProductId))
                {
                    _unitOfWork.Products.Update(category);
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

        public bool Remove(int categoryId, out List<string> errors)
        {
            errors = new List<string>();
            var category = _unitOfWork.Products.Get(filter: c => c.ProductId == categoryId,
                tracked: true);
            if (category is null)
            {
                errors.Add("Product does not exist");
                return false;
            }
            _unitOfWork.Products.Remove(category);
            var rowsAffected = _unitOfWork.Complete();
            return rowsAffected > 0;
        }
    }
}
