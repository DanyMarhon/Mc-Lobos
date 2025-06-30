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
            CreateMap<Locality, LocalityListDto>().ReverseMap();
            CreateMap<Locality, LocalityEditDto>().ReverseMap();
        }

        private void LoadCategoryMapping()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
        }

        private void LoadPaymentMethodMapping()
        {
            CreateMap<PaymentMethod, PaymentMethodListDto>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodEditDto>().ReverseMap();
        }
    }
}