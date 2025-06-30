using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;

namespace TPInvOp.Service.Interfaces
{
    public interface ICategoryService
    {
        bool Save(CategoryEditDto categoryDto, out List<string> errors);
        bool Remove(int categoryId, out List<string> errors);
        bool Exist(Category category, int? excludeId = null);
        CategoryEditDto? CategoryById(int id);
        IQueryable<CategoryListDto> GetAll();

    }
}

