using AutoMapper;
using BookShop2025.Service.DTOs.Category;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Locality;

namespace TPInvOp.Service.Mappers
{
    public class MappingProfileDto : Profile
    {
        public MappingProfileDto()
        {
            LoadCategoryMapping();
            LoadLocalityMapping();
        }

        private void LoadLocalityMapping()
        {
            CreateMap<Locality, LocalityListDto>();
            CreateMap<LocalityEditDto, Locality>();
        }

        private void LoadCategoryMapping()
        {
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryEditDto, Category>();
        }
    }
}