using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.Interfaces;

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

        public IQueryable<CategoryListDto> GetAll()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return _mapper.ProjectTo<CategoryListDto>(categories);
        }

        public CategoryEditDto? CategoryById(int id)
        {
            var category = _unitOfWork.Categories.Get(filter: c => c.CategoryId == id,
                tracked: true);
            if (category is null) return null;
            return _mapper.Map<CategoryEditDto>(category);
        }
        public bool Exist(Category category, int? excludeId = null)
        {
            return _unitOfWork.Categories.Exist(category, excludeId);
        }

        public bool Save(CategoryEditDto categoryDto, out List<string> errors)
        {
            errors = new List<string>();
            Category category = _mapper.Map<Category>(categoryDto);
            if (category.CategoryId == 0)
            {
                if (!_unitOfWork.Categories.Exist(category))
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
            else
            {
                if (!_unitOfWork.Categories.Exist(category, category.CategoryId))
                {
                    _unitOfWork.Categories.Update(category);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Category Already Exist!!");
                    return false;
                }

            }
        }
        public bool Remove(int categoryId, out List<string> errors)
        {
            errors = new List<string>();
            var category = _unitOfWork.Categories.Get(filter: c => c.CategoryId == categoryId,
                tracked: true);
            if (category is null)
            {
                errors.Add("Category does not exist");
                return false;
            }
            _unitOfWork.Categories.Remove(category);
            var rowsAffected = _unitOfWork.Complete();
            return rowsAffected > 0;
        }
    }
}
