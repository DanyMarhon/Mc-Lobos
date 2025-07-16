using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.DTOs.Employee;
using TPInvOp.Service.Interfaces;
using TPInvOp.Web.ViewModels.Category;
using TPInvOp.Web.ViewModels.Employee;
using X.PagedList;
using X.PagedList.Extensions;

namespace TPInvOp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public IActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int registerPerPage = pageSize ?? 8;

            var employeeDto = _employeeService.GetAll();
            var pagedListDto = employeeDto.ToPagedList(pageNumber, registerPerPage);
            var viewModelList = _mapper.Map<List<EmployeeListVm>>(pagedListDto);

            var viewModelPagedList = new StaticPagedList<EmployeeListVm>
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
            if (id is null || id == 0)
            {
                var model = new EmployeeEditVm()
                {
                    EmployeeId = 0
                };
                return View(model);
            }
            try
            {
                EmployeeEditDto? employeeDto = _employeeService.EmployeeById(id.Value);
                if (employeeDto is null)
                {
                    return NotFound($"Employee With Id {id} Not Found!!");
                }
                EmployeeEditVm employeeVm = _mapper.Map<EmployeeEditVm>(employeeDto);
                return View(employeeVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get an employee";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(EmployeeEditVm employeeVm)
        {
            if (ModelState.IsValid)
            {
                EmployeeEditDto employeeDto = _mapper.Map<EmployeeEditDto>(employeeVm);
                try
                {
                    if (_employeeService.Save(employeeDto, out var errors))
                    {
                        if (employeeDto.EmployeeId == 0)
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
                    }
                    return View(employeeVm);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "F!ck!! Something Happen" + ex.Message);
                }

            }
            return View(employeeVm);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                EmployeeEditDto? employeeDto = _employeeService.EmployeeById(id.Value);
                if (employeeDto is null)
                {
                    return NotFound($"Employee With Id {id} Not Found!!");
                }
                EmployeeEditVm employeeVm = _mapper.Map<EmployeeEditVm>(employeeDto);
                return View(employeeVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a employee";
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
                EmployeeEditDto? employeeDto = _employeeService.EmployeeById(id.Value);
                if (employeeDto is null)
                {
                    return NotFound($"Employee With Id {id} Not Found!!");
                }
                if (_employeeService.Remove(id.Value, out var errors))
                {
                    TempData["success"] = "Employee Succesfully Removed";
                    return RedirectToAction("Index");
                }
                else
                {
                    EmployeeEditVm employeeVm = _mapper.Map<EmployeeEditVm>(employeeDto);
                    ModelState.AddModelError(string.Empty, errors.First());
                    return View(employeeVm);

                }
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a employee";
                return RedirectToAction("Index");
            }

        }
    }
}


