using AutoMapper;
using BookShop2025.Service.DTOs.Category;
using BookShop2025.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.DTOs.Category;
using TPInvOp.Service.Interfaces;
using TPInvOp.Web.ViewModels.Category;

namespace TPInvOp.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categoriesDto = _categoryService.GetAll();
            var categoriesVm = _mapper.Map<List<CategoryListVm>>(categoriesDto);
            return View(categoriesVm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryEditVm categoryVm)
        {
            if (ModelState.IsValid)
            {
                CategoryEditDto categoryDto = _mapper.Map<CategoryEditDto>(categoryVm);
                try
                {
                    if (_categoryService.Add(categoryDto, out var errors))
                    {
                        TempData["success"] = "Register Successfully Added";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, errors.First());
                    }
                    return View(categoryVm);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "F!ck!! Something Happen" + ex.Message);
                }

            }
            return View(categoryVm);
        }
    }
}
