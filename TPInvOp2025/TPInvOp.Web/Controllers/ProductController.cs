using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Customer;
using TPInvOp.Service.DTOs.Employee;
using TPInvOp.Service.DTOs.Product;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Services;
using TPInvOp.Web.ViewModels.Customer;
using TPInvOp.Web.ViewModels.Employee;
using TPInvOp.Web.ViewModels.Product;
using X.PagedList;
using X.PagedList.Extensions;

namespace TPInvOp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public IActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int registerPerPage = pageSize ?? 8;

            var productDto = _productService.GetAll();
            var pagedListDto = productDto.ToPagedList(pageNumber, registerPerPage);
            var viewModelList = _mapper.Map<List<ProductListVm>>(pagedListDto);

            var viewModelPagedList = new StaticPagedList<ProductListVm>
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
            var categories = _categoryService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList();
            if (id is null || id == 0)
            {
                var model = new ProductEditVm()
                {
                    ProductId = 0,
                    Categories = categories
                };
                return View(model);
            }
            try
            {
                ProductEditDto? productDto = _productService.ProductById(id.Value);
                if (productDto is null)
                {
                    return NotFound($"Product With Id {id} Not Found!!");
                }
                ProductEditVm productVm = _mapper.Map<ProductEditVm>(productDto);
                productVm.Categories = categories;
                return View(productVm);
            }
            catch (Exception)
            {
                TempData["error"] = "Error while trying to get a product";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(ProductEditVm productVm)
        {
            var categories = _categoryService.GetAll()
          .Select(c => new SelectListItem
          {
              Value = c.CategoryId.ToString(),
              Text = c.CategoryName
          }).ToList();
            if (ModelState.IsValid)
            {
                ProductEditDto productDto = _mapper.Map<ProductEditDto>(productVm);
                try
                {
                    if (_productService.Save(productDto, out var errors))
                    {
                        if (productDto.ProductId == 0)
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
                        productVm.Categories = categories;
                    }
                    return View(productVm);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "F!ck!! Something Happen" + ex.Message);
                    productVm.Categories = categories;
                }

            }
            productVm.Categories = categories;
            return View(productVm);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            try
            {
                ProductEditDto? productDto = _productService.ProductById(id.Value);
                if (productDto is null)
                {
                    return NotFound($"Product With Id {id} Not Found!!");
                }
                ProductEditVm productVm = _mapper.Map<ProductEditVm>(productDto);
                return View(productVm);
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a product";
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
                ProductEditDto? productDto = _productService.ProductById(id.Value);
                if (productDto is null)
                {
                    return NotFound($"Product With Id {id} Not Found!!");
                }
                if (_productService.Remove(id.Value, out var errors))
                {
                    TempData["success"] = "Product Succesfully Removed";
                    return RedirectToAction("Index");
                }
                else
                {
                    ProductEditVm productVm = _mapper.Map<ProductEditVm>(productDto);
                    ModelState.AddModelError(string.Empty, errors.First());
                    return View(productVm);

                }
            }
            catch (Exception)
            {

                TempData["error"] = "Error while trying to get a product";
                return RedirectToAction("Index");
            }

        }
    }
}

