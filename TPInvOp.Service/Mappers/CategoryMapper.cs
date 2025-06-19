using TPInvOp.Model.DTOs.Category;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;

namespace TPInvOp.Service.Mappers
{
    public class CategoryMapper
    {
        public static Category CategoryEntity(CategoryCreateDto categoryCreateDto) => new()
        {
            CategoryId = categoryCreateDto.CategoryId,
            CategoryName = categoryCreateDto.CategoryName,
            Description = categoryCreateDto.Description,
        };

        public static CategoryDto CategoryDto(Category category) => new()
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        };
    }
}
