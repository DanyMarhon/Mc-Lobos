using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.Interfaces;
using TPInvOp.Web.ViewModels.Customer;
using X.PagedList;
using X.PagedList.Extensions;




namespace TPInvOp.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public IActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int registerPerPage = pageSize ?? 5;

            var customerDto = _customerService.GetAll();
            var pagedListDto = customerDto.ToPagedList(pageNumber, registerPerPage);
            var viewModelList = _mapper.Map<List<CustomerListVm>>(pagedListDto);

            var viewModelPagedList = new StaticPagedList<CustomerListVm>
                (
                    viewModelList,
                    pagedListDto.PageNumber,
                    pagedListDto.PageSize,
                   pagedListDto.TotalItemCount
                );
            return View(viewModelPagedList);
        }
    }
}
