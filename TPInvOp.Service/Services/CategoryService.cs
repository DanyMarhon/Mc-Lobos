using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Mappers;

namespace TPInvOp.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository = null!;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public bool Create(CategoryCreateDto categoryCreate, out List<string> errors)
        {
            errors = new List<string>();
            Category category = CategoryMapper.CategoryEntity(categoryCreate);
            if(_repository.Exist(category))
            {
                errors.Add(@"Category already exist");
                return false;
            }
            //Tenemos que crear el validador y validar.
            //En caso de ser valido guardamos.
            _repository.Add(category);
            _repository.SaveChanges();
            return true;
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
