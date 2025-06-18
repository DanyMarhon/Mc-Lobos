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
    }
}
