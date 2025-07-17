using AutoMapper;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Customer;
using TPInvOp.Service.DTOs.Employee;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.DTOs.PaymentMethod;
using TPInvOp.Service.DTOs.Product;
using TPInvOp.Web.ViewModels.Category;
using TPInvOp.Web.ViewModels.Customer;
using TPInvOp.Web.ViewModels.Employee;
using TPInvOp.Web.ViewModels.Locality;
using TPInvOp.Web.ViewModels.PaymentMethod;
using TPInvOp.Web.ViewModels.Product;

namespace TPInvOp.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadCategoryMapping();
            LoadLocalityMapping();
            LoadPaymentMethodMapping();
            LoadCustomerMapping();
            LoadEmployeeMapping();
            LoadProductMapping();
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
        private void LoadEmployeeMapping()
        {
            CreateMap<EmployeeListDto, EmployeeListVm>().ReverseMap();
            CreateMap<EmployeeEditVm, EmployeeEditDto>().ReverseMap();
        }

        private void LoadCustomerMapping()
        {
            CreateMap<CustomerListDto, CustomerListVm>().ReverseMap();
            CreateMap<CustomerEditDto, CustomerEditVm>().ReverseMap();
            CreateMap<CustomerEditDto, CustomerListVm>();
        }
        private void LoadProductMapping()
        {
            CreateMap<ProductListDto, ProductListVm>().ReverseMap();
            CreateMap<ProductEditDto, ProductEditVm>().ReverseMap();
            CreateMap<ProductEditDto, ProductListVm>();
        }

    }
}
