using TPInvOp.Data.Interfaces;
using TPInvOp.Model.DTOs.Category;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Mappers;
using TPInvOp.Service.Validators;

namespace TPInvOp.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository = null!;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category? CategoryById(int id, bool tracked = false)
        {
            return _repository.GetById(id, tracked);
        }

        public bool Create(CategoryCreateDto categoryCreate, out List<string> errors)
        {
            errors = new List<string>();
            Category category = CategoryMapper.CategoryEntity(categoryCreate);
            if(_repository.Exist(category.CategoryName, category.CategoryId))
            {
                errors.Add(@"Category already exist");
                return false;
            }
            CategoryValidator categoryValidator = new CategoryValidator();
            if(!UniversalValidator.IsValid(category, categoryValidator, out errors))
            {
                return false;
            }
            _repository.Add(category);
            _repository.SaveChanges();
            return true;
        }

        public void Delete(int categoryId)
        {
            _repository.Delete(categoryId);
        }

        public bool Exist(string name, int? excludeId = null)
        {
            return _repository.Exist(name, excludeId);
        }

        public IEnumerable<CategoryDto> GetAll(string? sortedBy = null)
        {
            var categories = _repository.GetAll(sortedBy);
            return categories.Select(CategoryMapper.CategoryDto).ToList();
        }
    }
}
