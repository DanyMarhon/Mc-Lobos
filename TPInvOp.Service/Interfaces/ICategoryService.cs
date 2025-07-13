using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;

namespace TPInvOp.Service.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<CategoryListDto> GetAll();
        CategoryEditDto? CategoryById(int id);
        bool Exist(Category category, int? excludeId = null);
        bool Save(CategoryEditDto categoryDto, out List<string> errors);
        bool Remove(int categoryId, out List<string> errors);
    }
}

