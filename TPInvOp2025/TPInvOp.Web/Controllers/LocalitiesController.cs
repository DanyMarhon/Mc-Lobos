using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.Interfaces;
using TPInvOp.Web.ViewModels.Locality;
using X.PagedList;
using X.PagedList.Extensions;

namespace TPInvOp.Web.Controllers
{
    public class LocalitiesController : Controller
    {
        private readonly ILocalityService _localityService;
        private readonly IMapper _mapper;

        public LocalitiesController(ILocalityService localityService, IMapper mapper)
        {
            _localityService = localityService;
            _mapper = mapper;
        }
        public IActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int registerPerPage = pageSize ?? 8;

            var localitiesDto = _localityService.GetAll();
            var pagedListDto = localitiesDto.ToPagedList(pageNumber, registerPerPage);
            var viewModelList = _mapper.Map<List<LocalityListVm>>(pagedListDto);

            var viewModelPagedList = new StaticPagedList<LocalityListVm>
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
                var model = new LocalityEditVm()
                {
                    LocalityId = 0
                };
                return View(model);
            }
            try
            {
                LocalityEditDto? localityDto = _localityService.LocalityById(id.Value);
                if (localityDto is null)
                {
                    return NotFound($"Locality With Id {id} Not Found!!");
                }
                LocalityEditVm localityVm = _mapper.Map<LocalityEditVm>(localityDto);
                return View(localityVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a locality";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(LocalityEditVm localityVm)
        {
            if (ModelState.IsValid)
            {
                LocalityEditDto localityDto = _mapper.Map<LocalityEditDto>(localityVm);
                try
                {
                    if (_localityService.Save(localityDto, out var errors))
                    {
                        if(localityDto.LocalityId == 0)
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
                    return View(localityVm);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "F!ck!! Something Happen" + ex.Message);
                }

            }
            return View(localityVm);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                LocalityEditDto? localityDto = _localityService.LocalityById(id.Value);
                if (localityDto is null)
                {
                    return NotFound($"Locality With Id {id} Not Found!!");
                }
                LocalityEditVm localityVm = _mapper.Map<LocalityEditVm>(localityDto);
                return View(localityVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a locality";
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
                LocalityEditDto? localityDto = _localityService.LocalityById(id.Value);
                if (localityDto is null)
                {
                    return NotFound($"Locality With Id {id} Not Found!!");
                }
                if (_localityService.Remove(id.Value, out var errors))
                {
                    TempData["success"] = "Locality Succesfully Removed";
                    return RedirectToAction("Index");
                }
                else
                {
                    LocalityEditVm localityVm = _mapper.Map<LocalityEditVm>(localityDto);
                    ModelState.AddModelError(string.Empty, errors.First());
                    return View(localityVm);

                }
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a locality";
                return RedirectToAction("Index");
            }

        }
    }
}
