using AutoMapper;
using BookShop2025.Service.DTOs.Category;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Validators;

namespace TPInvOp.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CategoryListDto> GetAll()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }

        public bool Save(CategoryEditDto categoryDto, out List<string> errors)
        {
            errors = new List<string>();
            Category category = _mapper.Map<Category>(categoryDto);
            if (!_unitOfWork.Categories.Exist(category.CategoryName))
            {
                _unitOfWork.Categories.Add(category);
                int rowsAffected = _unitOfWork.Complete();
                return rowsAffected > 0;

            }
            else
            {
                errors.Add("Category Already Exist!!");
                return false;
            } 
        }

        public Category? CategoryById(int id, bool tracked = false)
        {
            return _unitOfWork.Categories.GetById(id, tracked);
        }


        public void Delete(int categoryId)
        {
            _unitOfWork.Categories.Delete(categoryId);
        }

        public bool Exist(string name, int? excludeId = null)
        {
            return _unitOfWork.Categories.Exist(name, excludeId);
        }

        public IEnumerable<CategoryListDto> GetAll(string? sortedBy = null)
        {
            var categories = _unitOfWork.Categories.GetAll(sortedBy);
            return _mapper.Map<List<CategoryListDto>>(categories);
        }
    }
}
