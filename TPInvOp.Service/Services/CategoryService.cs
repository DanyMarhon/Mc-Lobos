using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;
using TPInvOp.Service.Interfaces;

namespace TPInvOp.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository = null!;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
