using AutoMapper;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.DTOs.PaymentMethod;
using TPInvOp.Web.ViewModels.Category;
using TPInvOp.Web.ViewModels.Locality;
using TPInvOp.Web.ViewModels.PaymentMethod;

namespace TPInvOp.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadCategoryMapping();
            LoadLocalityMapping();
            LoadPaymentMethodMapping();
        }

        private void LoadLocalityMapping()
        {
            CreateMap<LocalityListDto, LocalityListVm>().ReverseMap();
            CreateMap<LocalityEditVm, LocalityEditDto>().ReverseMap();
        }

        private void LoadCategoryMapping()
        {
            CreateMap<CategoryListDto, CategoryListVm>().ReverseMap();
            CreateMap<CategoryEditVm, CategoryEditDto>().ReverseMap();
        }
        private void LoadPaymentMethodMapping()
        {
            CreateMap<PaymentMethodListDto, PaymentMethodListVm>().ReverseMap();
            CreateMap<PaymentMethodEditVm, PaymentMethodEditDto>().ReverseMap();

        }
    }
}
