using AutoMapper;
using BookShop2025.Service.DTOs.Category;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;

namespace TPInvOp.Service.Mappers
{
    public class MappingProfileDto : Profile
    {
        public MappingProfileDto()
        {
            LoadCategoryMapping();
        }

        private void LoadCategoryMapping()
        {
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryEditDto, Category>();
        }
    }
}