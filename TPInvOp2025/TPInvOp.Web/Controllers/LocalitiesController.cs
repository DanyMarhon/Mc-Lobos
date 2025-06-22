using AutoMapper;
using BookShop2025.Service.DTOs.Category;
using BookShop2025.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Services;
using TPInvOp.Web.ViewModels.Category;
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
        public IActionResult Create(LocalityEditVm localityVm)
        {
            if (ModelState.IsValid)
            {
                LocalityEditDto localityDto = _mapper.Map<LocalityEditDto>(localityVm);
                try
                {
                    if (_localityService.Add(localityDto, out var errors))
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
    }
}
