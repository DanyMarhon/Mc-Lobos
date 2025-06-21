using BookShop2025.Service.DTOs.Category;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;

namespace TPInvOp.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryListDto> GetAll();
        bool Add(CategoryEditDto categoryDto, out List<string> errors);
        void Delete(int categoryId);
        bool Exist(string name, int? excludeId = null);
        Category? CategoryById(int id, bool tracked = false);
        IEnumerable<CategoryListDto> GetAll(string? sortedBy = null);

    }
}

