using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.Interfaces;
using TPInvOp.Web.ViewModels.Locality;

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
        public IActionResult Index()
        {
            var localitiesDto = _localityService.GetAll();
            var localitiesVm = _mapper.Map<List<LocalityListVm>>(localitiesDto);
            return View(localitiesVm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LocalityEditVm localityVm)
        {
            if (ModelState.IsValid)
            {
                LocalityEditDto localityDto = _mapper.Map<LocalityEditDto>(localityVm);
                try
                {
                    if (_localityService.Save(localityDto, out var errors))
                    {
                        TempData["success"] = "Register Successfully Added";
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
        public IActionResult Edit(int? id)
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
        public IActionResult Edit(LocalityEditVm localityVm)
        {
            if (ModelState.IsValid)
            {
                LocalityEditDto localityDto = _mapper.Map<LocalityEditDto>(localityVm);
                try
                {
                    if (_localityService.Save(localityDto, out var errors))
                    {
                        TempData["success"] = "Register Successfully Updated";
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
