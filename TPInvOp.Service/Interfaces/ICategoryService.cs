using TPInvOp.Model.DTOs.Category;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;

namespace TPInvOp.Service.Interfaces
{
    public interface ICategoryService
    {
        bool Create(CategoryCreateDto categoryCreate, out List<string> errors);
        void Delete(int categoryId);
        bool Exist(string name, int? excludeId = null);
        Category? CategoryById(int id, bool tracked = false);
        IEnumerable<CategoryDto> GetAll(string? sortedBy = null);

    }
}

