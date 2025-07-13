using AutoMapper;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Customer;
using TPInvOp.Service.DTOs.Employee;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.DTOs.PaymentMethod;
using TPInvOp.Service.DTOs.Product;

namespace TPInvOp.Service.Mappers
{
    public class MappingProfileDto : Profile
    {
        public MappingProfileDto()
        {
            LoadCategoryMapping();
            LoadLocalityMapping();
            LoadPaymentMethodMapping();
            LoadEmployeeMapping();
            LoadCustomerMapping();
            LoadProductMapping();
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
        private void LoadEmployeeMapping()
        {
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Employee, EmployeeEditDto>().ReverseMap();
        }
        private void LoadCustomerMapping()
        {
            CreateMap<Customer, CustomerListDto>()
                .ForMember(dest => dest.LocalityName, opt => opt.MapFrom(src => src.Locality!.LocalityName));
            CreateMap<Customer, CustomerEditDto>().ReverseMap();
        }
        private void LoadProductMapping()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, ProductEditDto>().ReverseMap();
        }
    }
}