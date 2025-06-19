using Microsoft.AspNetCore.Mvc;
using TPInvOp.Service.Interfaces;

namespace TPInvOp.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll("NAME");
            return View(categories);
        }
        
        public IActionResult Create()
        {
            return View();
        }
    }
}
