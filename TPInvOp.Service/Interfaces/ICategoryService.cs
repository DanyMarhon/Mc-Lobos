using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;

namespace TPInvOp.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        bool Create(CategoryCreateDto categoryCreate, out List<string> errors);
    }
}

