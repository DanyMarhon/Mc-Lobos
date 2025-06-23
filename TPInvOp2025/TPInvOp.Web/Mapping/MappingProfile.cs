using AutoMapper;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Web.ViewModels.Category;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Web.ViewModels.Category;
using TPInvOp.Web.ViewModels.Locality;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.PaymentMethod;
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
            CreateMap<LocalityListDto, LocalityListVm>();
            CreateMap<LocalityEditVm, LocalityEditDto>();
        }

        private void LoadCategoryMapping()
        {
            CreateMap<CategoryListDto, CategoryListVm>();
            CreateMap<CategoryEditVm, CategoryEditDto>();
        }
        private void LoadPaymentMethodMapping()
        {
            CreateMap<PaymentMethodListDto, PaymentMethodListVm>();
            CreateMap<PaymentMethodEditVm, PaymentMethodEditDto>();
         
        }
    }
}
