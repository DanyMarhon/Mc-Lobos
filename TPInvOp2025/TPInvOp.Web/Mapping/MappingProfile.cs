using AutoMapper;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Web.ViewModels.Category;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Web.ViewModels.Category;
using TPInvOp.Web.ViewModels.Locality;

namespace TPInvOp.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadCategoryMapping();
            LoadLocalityMapping();
        }

        private void LoadLocalityMapping()
        {
            CreateMap<LocalityListDto, LocalityListVm>();
            CreateMap<LocalityEditVm, LocalityEditDto>();
        }

        private void LoadCategoryMapping()
        {
            CreateMap<CategoryListDto, CategoryListVm>();
            CreateMap<CategoryEditVm, CategoryEditDto>();
        }
    }
}
