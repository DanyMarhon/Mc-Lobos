using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPInvOp.Service.DTOs.Customer;
using TPInvOp.Service.Interfaces;
using TPInvOp.Web.ViewModels.Customer;
using X.PagedList;
using X.PagedList.Extensions;




namespace TPInvOp.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILocalityService _localityService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper, ILocalityService localityService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _localityService = localityService;
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


        public IActionResult Upsert(int? id)
        {
            var localities = _localityService.GetAll()
                .Select(l => new SelectListItem
                {
                    Value = l.LocalityId.ToString(),
                    Text = l.LocalityName
                }).ToList();
            if (id is null || id == 0)
            {
                var model = new CustomerEditVm()
                {
                    CustomerId = 0,
                    Localities = localities
                };
                return View(model);
            }
            try
            {
                CustomerEditDto? customerDto = _customerService.CustomerById(id.Value);
                if (customerDto is null)
                {
                    return NotFound($"Customer With Id {id} Not Found!!");
                }
                CustomerEditVm customerVm = _mapper.Map<CustomerEditVm>(customerDto);
                customerVm.Localities = localities;
                return View(customerVm);
            }
            catch (Exception)
            {
                TempData["error"] = "Error while trying to get a customer";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CustomerEditVm customerVm)
        {
            var localities = _localityService.GetAll()
            .Select(l => new SelectListItem
            {
                Value = l.LocalityId.ToString(),
                Text = l.LocalityName
            }).ToList();
            if (ModelState.IsValid)
            {
                CustomerEditDto customerDto = _mapper.Map<CustomerEditDto>(customerVm);
                try
                {
                    if (_customerService.Save(customerDto, out var errors))
                    {
                        if (customerDto.CustomerId == 0)
                        {
                            TempData["success"] = "Register Successfully Added";
                        }
                        else
                        {
                            TempData["success"] = "Register Successfully Updated";
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, errors.First());
                        customerVm.Localities = localities;
                    }
                    return View(customerVm);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "F!ck!! Something Happen" + ex.Message);
                    customerVm.Localities = localities;
                }

            }
            customerVm.Localities = localities;
            return View(customerVm);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                CustomerEditDto? customerDto = _customerService.CustomerById(id.Value);
                if (customerDto is null)
                {
                    return NotFound($"Customer With Id {id} Not Found!!");
                }
                CustomerEditVm customerVm = _mapper.Map<CustomerEditVm>(customerDto);
                return View(customerVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a customer";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                CustomerEditDto? customerDto = _customerService.CustomerById(id.Value);
                if (customerDto is null)
                {
                    return NotFound($"Customer With Id {id} Not Found!!");
                }
                if (_customerService.Remove(id.Value, out var errors))
                {
                    TempData["success"] = "Customer Succesfully Removed";
                    return RedirectToAction("Index");
                }
                else
                {
                    CustomerEditVm customerVm = _mapper.Map<CustomerEditVm>(customerDto);
                    ModelState.AddModelError(string.Empty, errors.First());
                    return View(customerVm);

                }
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a customer";
                return RedirectToAction("Index");
            }

        }
    }
}
