using AutoMapper;
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryEditVm categoryVm)
        {
            if (ModelState.IsValid)
            {
                CategoryEditDto categoryDto = _mapper.Map<CategoryEditDto>(categoryVm);
                try
                {
                    if (_categoryService.Save(categoryDto, out var errors))
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
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                CategoryEditDto? categoryDto = _categoryService.CategoryById(id.Value);
                if (categoryDto is null)
                {
                    return NotFound($"Category With Id {id} Not Found!!");
                }
                CategoryEditVm categoryVm = _mapper.Map<CategoryEditVm>(categoryDto);
                return View(categoryVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a category";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditVm categoryVm)
        {
            if (ModelState.IsValid)
            {
                CategoryEditDto categoryDto = _mapper.Map<CategoryEditDto>(categoryVm);
                try
                {
                    if (_categoryService.Save(categoryDto, out var errors))
                    {
                        TempData["success"] = "Register Successfully Updated";
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
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                CategoryEditDto? categoryDto = _categoryService.CategoryById(id.Value);
                if (categoryDto is null)
                {
                    return NotFound($"Category With Id {id} Not Found!!");
                }
                CategoryEditVm categoryVm = _mapper.Map<CategoryEditVm>(categoryDto);
                return View(categoryVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a category";
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
                CategoryEditDto? categoryDto = _categoryService.CategoryById(id.Value);
                if (categoryDto is null)
                {
                    return NotFound($"Category With Id {id} Not Found!!");
                }
                if (_categoryService.Remove(id.Value, out var errors))
                {
                    TempData["success"] = "Category Succesfully Removed";
                    return RedirectToAction("Index");
                }
                else
                {
                    CategoryEditVm categoryVm = _mapper.Map<CategoryEditVm>(categoryDto);
                    ModelState.AddModelError(string.Empty, errors.First());
                    return View(categoryVm);

                }
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a category";
                return RedirectToAction("Index");
            }

        }
    }
}
