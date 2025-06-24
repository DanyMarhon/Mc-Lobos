using AutoMapper;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.DTOs.PaymentMethod;

namespace TPInvOp.Service.Mappers
{
    public class MappingProfileDto : Profile
    {
        public MappingProfileDto()
        {
            LoadCategoryMapping();
            LoadLocalityMapping();
            LoadPaymentMethodMapping();
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

        private void LoadPaymentMethodMapping()
        {
            CreateMap<PaymentMethod, PaymentMethodListDto>();
            CreateMap<PaymentMethodEditDto, PaymentMethod>();
        }
    }
}